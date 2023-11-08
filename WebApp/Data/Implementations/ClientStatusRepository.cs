using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class ClientStatusRepository : Repository<ClientStatus>, IClientStatusRepository
    {
        public ClientStatusRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<object>> GetAllClientStatuses()
        {
            var list = await _context.ClientStatuses
            .OrderBy(e => e.ClientStatusID)
            .Select(status => new
            {
                status.ClientStatusID,
                status.Name
            }).ToListAsync();
            return list;
        }
    }
}