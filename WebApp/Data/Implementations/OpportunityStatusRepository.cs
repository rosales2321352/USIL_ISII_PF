using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OpportunityStatusRepository : Repository<OpportunityStatus>, IOpportunityStatusRepository
    {
        public OpportunityStatusRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllOpportunityStatuses()
        {
            var lista = await _context.OpportunityStatuses
            .OrderBy(e => e.OpportunityStatusID)
            .Select(status => new
            {
                status.OpportunityStatusID,
                status.Name
            }).ToListAsync();

            return lista;
        }
    }
}