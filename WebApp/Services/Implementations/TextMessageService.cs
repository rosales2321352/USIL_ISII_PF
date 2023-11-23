using WebApp.Data;
using WebApp.Models;
using Newtonsoft.Json;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Net.Http.Headers;
namespace WebApp.Services
{
    public class TextMessageService : Service<TextMessage>, ITextMessageService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ITextMessageRepository _textMessageRepository;
        public TextMessageService(IServiceProvider serviceProvider, ITextMessageRepository repository) : base(repository)
        {
            _serviceProvider = serviceProvider;
            _textMessageRepository = repository;
        }

        public async Task<TextMessage> CreateMessage(WebHookResponseModel request)
        {
            IClientService clientService = _serviceProvider.GetRequiredService<IClientService>();
            IWhatsappDataService wzpService = _serviceProvider.GetRequiredService<IWhatsappDataService>();
            IConversationService conversationService = _serviceProvider.GetRequiredService<IConversationService>();

            Client? client = await clientService.GetClientByWhatsappId(request.Entry[0].Changes[0].Value.Contacts[0].Wa_id);
            int conversationId;

            //TODO! Separar
            if (client is null)
            {
                // Crear el WZPData, Cliente y Conversation
                await wzpService.CreateWhatsappDataFromJSON(request);
                int clientID = await clientService.CreateClientFromJSON(request);
                conversationId = await conversationService.CreateConversartion(clientID);
            }
            else
            {
                Conversation? conversation = await conversationService.GetConversationByClient(client.PersonID);
                conversationId = conversation.ConversationID;
            }

            // Convertir el DateTime en UTC a la zona horaria de Lima
            long timestamp = long.Parse(request.Entry[0].Changes[0].Value.Messages[0].Timestamp);
            DateTime dateTimeUtc = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime;
            TimeZoneInfo zonaHorariaInfoLima = TimeZoneInfo.FindSystemTimeZoneById("America/Lima");
            DateTime horaLima = TimeZoneInfo.ConvertTime(dateTimeUtc, TimeZoneInfo.Utc, zonaHorariaInfoLima);

            TextMessage textMessage = new()
            {
                MessageID = request.Entry[0].Changes[0].Value.Messages[0].Id,
                Timestamp = horaLima,
                WhatsappID = request.Entry[0].Changes[0].Value.Messages[0].From,
                MessageTypeId = 1,
                ConversationID = conversationId,
                Text = request.Entry[0].Changes[0].Value.Messages[0].Text.Body,
            };

            await _repository.Add(textMessage);

            return textMessage;

        }

        public async Task SendMessage(TextMessageRequest request)
        {
            //! Falta token permanente
            string token = "EAAEfe408O1kBO9CCPl1Yo4NZB0qZA1B8uJoHQR8am7F3YxzPqHWHMutyc7aWt4y0vZAdEALZAWR8bHKRChrWlWDo5KExiwSYMmfClK2f2OFkUKyrMlDznWCZAZBNOzEs0cbrHH7dmntqU2UotQNUEOa46JV4QFz2OUZB6xHN42Wvc3GODmmitnZAZA7fBYLyholTHCIcZAornCTqGKZCfeek58ZD";
            string url = "https://graph.facebook.com/v15.0/144739755381611/messages";

            var message = new SendMessageRequest
            {
                MessagingProduct = "whatsapp",
                RecipientType = "individual",
                To = request.PhoneNumber,
                Type = "text",
                Text = new SendMessageRequest.TextContent
                {
                    PreviewUrl = false,
                    Body = request.Text
                }
            };

            string jsonBody = JsonConvert.SerializeObject(message);

            Console.WriteLine(jsonBody);

            using var client = new HttpClient();

            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Post, url);
            req.Headers.Add("Authorization", "Bearer " + token);
            req.Content = new StringContent(jsonBody);
            req.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            HttpResponseMessage response = await client.SendAsync(req);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Solicitud exitosa. Respuesta: " + await response.Content.ReadAsStringAsync());

                string jsonResponse = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(jsonResponse))
                {
                    WhatsAppResponse responseObject = JsonConvert.DeserializeObject<WhatsAppResponse>(jsonResponse) ?? new WhatsAppResponse();
                    await SaveTextMessage(responseObject, request.ConversationID, request.Text);
                }
            }
            else
            {
                Console.WriteLine("Error al enviar la solicitud. Código de estado: " + response.StatusCode);
            }
        }

        public async Task SaveTextMessage(WhatsAppResponse request, int conversationId, string text)
        {
            TextMessage textMessage = new()
            {
                MessageID = request.Messages[0].Id,
                Timestamp = DateTime.Now,
                WhatsappID = "144739755381611",
                MessageTypeId = 1,
                ConversationID = conversationId,
                Text = text,
            };
            await _repository.Add(textMessage);
        }
    }
}