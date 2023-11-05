using WebApp.Models;
namespace WebApp.Services
{
    public interface IEventService : IService<Event>
    {
        Task<IEnumerable<object>> GetAllEvents();
        Task<object> GetEventDetail(int id);
        Task<IEnumerable<object>> GetAllEventsByClient(int id);
        Task CreateEvent(EventRequest request);
        Task EditEvent(EventUpdate request);
        Task DeleteEvent(EventDelete request);
    }
}