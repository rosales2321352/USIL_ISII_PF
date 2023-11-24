using WebApp.Models;
namespace WebApp.Services
{
    public interface IConversationService : IService<Conversation>
    {
        Task<int> CreateConversartion(int clientID);
        Task<Conversation?> GetConversationByClient(int id);
        Task<IEnumerable<object>> GetCompleteConversation(int id);
    }
}