using WebApp.Models;
namespace WebApp.Services
{
    public interface IEventService : IService<Event>
    {
        Task<IEnumerable<object>> GetAllEvents();
        Task<object> GetEventDetail(int id);
        Task<IEnumerable<object>> GetAllEventsByClient(int id);
        Task<object> CreateEvent(EventRequest request);
        Task<object> EditEvent(EventUpdate request);
        Task DeleteEvent(EventDelete request);
    }
}