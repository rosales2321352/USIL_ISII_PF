using WebApp.Models;
namespace WebApp.Services
{
    public interface IEventTypeService : IService<EventType>
    {
        Task<IEnumerable<object>> GetAllEventTypes();
        Task<object> CreateEventType(EventTypeRequest request);
        Task<object> EditEventType(EventTypeRequest request);
        Task DeleteEventType(int eventTypeID);
    }
}