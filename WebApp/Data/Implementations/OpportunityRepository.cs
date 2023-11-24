using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<object>> GetAllOpportunities()
        {
            var lista = await _context.Opportunities
            .OrderByDescending(e => e.OpportunityID)
            .Select(opportunity => new
            {
                opportunity.OpportunityID,
                opportunity.CreationDate,
                Client = new
                {
                    opportunity.Client.Name
                },
                Status = new
                {
                    opportunity.OpportunityStatus.Name,
                    opportunity.OpportunityID
                }
            }).ToListAsync();

            return lista;
        }

        public async Task<object> GetOpportunityById(int id)
        {
            var order = await _context.Opportunities
            .Select(e => new
            {
                e.OpportunityID,
                e.CreationDate,
                Client = new
                {
                    e.Client.Name,
                    e.Client.PhoneNumber,
                },
                Status = new
                {
                    e.OpportunityStatus.Name,
                    e.OpportunityStatusID,
                }
            })
            .FirstOrDefaultAsync(e => e.OpportunityID == id);
            if (order != null)
                return order;
            else
                return default!;    //TODO! Que se retorna?
        }

        public async Task<IEnumerable<object>> GetOpportunityByStatus(int id)
        {
            var lista = await _context.Opportunities
            .OrderByDescending( e=> e.OpportunityID)
            .Where( e=> e.OpportunityStatusID ==id)
            .Select(opportunity => new 
            {
                opportunity.OpportunityID,
                opportunity.CreationDate,
                Client = new
                {
                    opportunity.Client.Name
                },
                Status = new
                {
                    opportunity.OpportunityStatus.Name,
                    opportunity.OpportunityID
                }
            }).ToListAsync();

            return lista;
        }
    }
}