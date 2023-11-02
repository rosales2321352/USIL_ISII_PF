using WebApp.Models;
namespace WebApp.Data
{
    public interface IEventRepository  : IRepository<Event>
    {
        Task<IEnumerable<object>> GetAllEvents();
        Task<IEnumerable<object>> GetAllEventsByClient(int id);
        Task<object> GetEventDetail(int id);
    }
}
