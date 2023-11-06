using WebApp.Models;
namespace WebApp.Services
{
    public interface IConversationService : IService<Conversation>
    {
        Task<int> CreateConversartion(Conversation request);
        Task<Conversation?> GetConversationByClient(int id);
    }
}