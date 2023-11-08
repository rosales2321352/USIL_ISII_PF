using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class EventTypeRepository : Repository<EventType>, IEventTypeRepository
    {
        public EventTypeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllEventTypes()
        {
            var list = await _context.EventTypes
            .OrderBy(e => e.EventTypeID)
            .Select(type => new
            {
                type.EventTypeID,
                type.Name
            }).ToListAsync();

            return list;
        }
    }
}