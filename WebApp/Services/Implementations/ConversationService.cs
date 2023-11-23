using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class ConversationService : Service<Conversation>, IConversationService
    {
        private readonly IConversationRepository _conversationRepository;
        public ConversationService(IConversationRepository repository) : base(repository)
        {
            _conversationRepository = repository;
        }

        public async Task<int> CreateConversartion(int clientID)
        {
            Conversation conversation = new()
            {
                SellerID = 1,
                ClientID = clientID,
                StartDate = DateOnly.FromDateTime(DateTime.Now)
            };
            await _repository.Add(conversation);
            return conversation.ConversationID;
        }

        public async Task<Conversation?> GetConversationByClient(int id)
        {
            return await _conversationRepository.GetByClientId(id);
        }

        public async Task<IEnumerable<object>> GetCompleteConversation(int id)
        {
            return await _conversationRepository.GetCompleteConversation(id);
        }
    }
}