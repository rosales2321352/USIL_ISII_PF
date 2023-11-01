using WebApp.Models;
namespace WebApp.Data
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context) { }
    }
}