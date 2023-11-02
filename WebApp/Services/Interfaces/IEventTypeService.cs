using WebApp.Models;
namespace WebApp.Services
{
    public interface IEventTypeService : IService<EventType>
    {
        Task<IEnumerable<object>> GetAllEventTypes();
        Task CreateEventType(EventTypeRequest request);
        Task EditEventType(EventTypeRequest request);
    }
}