using WebApp.Models;
namespace WebApp.Data
{
    public interface IEventTypeRepository : IRepository<EventType>
    {
        Task<IEnumerable<object>> GetAllEventTypes();
    }
}
