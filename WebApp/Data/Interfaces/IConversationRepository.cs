using WebApp.Models;
namespace WebApp.Data
{
    public interface IConversationRepository : IRepository<Conversation>
    {
        Task<Conversation?> GetByClientId(int id);
    }
}