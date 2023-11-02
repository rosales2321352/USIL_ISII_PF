using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        public EventRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllEvents()
        {
            var list = await _context.Events
            .OrderByDescending(e => e.EventID)
            .Select(e => new 
            {
                e.EventID,
                e.Title,
                e.DateAssigned,
                e.BeginTime,
                e.EndTime,
                e.Description,
                Client = new
                {
                    e.Client.Name,
                    e.Client.PhoneNumber,
                    e.Client.Email
                },
                Status = new 
                {
                    e.EventTypeID,
                    e.EventType.Name
                }
            }).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<object>> GetAllEventsByClient(int id)
        {
            var list = await _context.Events
            .OrderByDescending(e => e.EventID)
            .Where(e => e.ClientID == id)
            .Select(e => new 
            {
                e.EventID,
                e.Title,
                e.DateAssigned,
                e.BeginTime,
                e.EndTime,
                e.Description,
                Client = new
                {
                    e.Client.Name,
                    e.Client.PhoneNumber,
                    e.Client.Email
                },
                Status = new 
                {
                    e.EventTypeID,
                    e.EventType.Name
                }
            }).ToListAsync();

            return list;
        }

        public async Task<object> GetEventDetail(int id)
        {
            var eve = await _context.Events
            .OrderByDescending(e => e.EventID)
            .Select(e => new 
            {
                e.EventID,
                e.Title,
                e.DateAssigned,
                e.BeginTime,
                e.EndTime,
                e.Description,
                Client = new
                {
                    e.Client.Name,
                    e.Client.PhoneNumber,
                    e.Client.Email
                },
                Status = new 
                {
                    e.EventTypeID,
                    e.EventType.Name
                }
            }).FirstOrDefaultAsync(e => e.EventID == id);
            
            if (eve is null)
                return default!; 
            else
            //TODO! 
                return eve;
        }
    }
}