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

        public async Task<int> CreateConversartion(Conversation request)
        {
            await _repository.Add(request);
            return request.ConversationID;
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