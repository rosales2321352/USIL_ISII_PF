using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class EventService : Service<Event>, IEventService
    {
        public EventService(IEventRepository repository) : base(repository) { }
    }
}