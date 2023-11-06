using WebApp.Data;
using WebApp.Models;
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

        public async Task CreateMessage(WebHookResponseModel request)
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
            }
        }
    }
}