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

            //TODO! Separar
            if (client is null)
            {
                WhatsappData whatsappData = new()
                {
                    WhatsappID = request.Entry[0].Changes[0].Value.Contacts[0].Wa_id,
                    PhonenumberCode = request.Entry[0].Changes[0].Value.Messages[0].From,
                    WhatsappName = request.Entry[0].Changes[0].Value.Contacts[0].Profile.Name
                };

                await wzpService.CreateWhatsappData(whatsappData);

                ClientRequest newClient = new()
                {
                    WhatsappID = request.Entry[0].Changes[0].Value.Contacts[0].Wa_id,
                    PhoneNumber = request.Entry[0].Changes[0].Value.Messages[0].From
                };
                int clientID = await clientService.CreateClient(newClient);

                Conversation conversation = new()
                {
                    SellerID = 1,
                    ClientID = clientID,
                    StartDate = DateOnly.FromDateTime(DateTime.Now)
                };

                int conversationId = await conversationService.CreateConversartion(conversation);

                long timestamp = long.Parse(request.Entry[0].Changes[0].Value.Messages[0].Timestamp);
                TextMessage textMessage = new()
                {
                    MessageID = request.Entry[0].Changes[0].Value.Messages[0].Id,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime,
                    WhatsappID = request.Entry[0].Changes[0].Value.Messages[0].From,
                    MessageTypeId = 1,
                    ConversationID = conversationId,
                    Text = request.Entry[0].Changes[0].Value.Messages[0].Text.Body,
                };

                await _repository.Add(textMessage);

                return textMessage;
            }
            else
            {
                Conversation? conversation = await conversationService.GetConversationByClient(client.PersonID);
                long timestamp = long.Parse(request.Entry[0].Changes[0].Value.Messages[0].Timestamp);
                TextMessage textMessage = new()
                {
                    MessageID = request.Entry[0].Changes[0].Value.Messages[0].Id,
                    Timestamp = DateTimeOffset.FromUnixTimeSeconds(timestamp).DateTime,
                    WhatsappID = request.Entry[0].Changes[0].Value.Messages[0].From,
                    MessageTypeId = 1,
                    ConversationID = conversation.ConversationID,
                    Text = request.Entry[0].Changes[0].Value.Messages[0].Text.Body,
                };
                await _repository.Add(textMessage);
                return textMessage;
            }

        }

        public async Task SendMessage(TextMessageRequest request)
        {
            string token = "EAAEfe408O1kBOxEJQtg2kPZCIhJieOeIZBeahkRpAR2Tc5VlIyxZCsWPf2tZA4mmZAk7GDfZBrxgBdsXAZC7QBBZBTk82vgzlF0Kf91YGBFyvkd3nNuzIYw0GpkZAuSlAksmSsygxVlXHKZAnB6XWZA5EiWhIp5DZBqeiUCLeWgokRUo3gZBg5ussF48tulGDecO2YZAsPuJtxhfKQt4RqhqZAxflcZD";
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
                WhatsappID = request.Contacts[0].Input,
                MessageTypeId = 1,
                ConversationID = conversationId,
                Text = text,
            };
            await _repository.Add(textMessage);
        }
    }
}