using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OpportunityHistoryRepository : Repository<OpportunityStatusHistory>, IOpportunityHistoryRepository
    {
        public OpportunityHistoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<object>> GetOpportunitiesHistory(int id)
        {
            var lista = await _context.OpportunityStatusHistories
            .OrderBy(e => e.UpdateDate)
            .Where(e => e.OpportunityID == id)
            .Select(track => new
            {
                Date = track.UpdateDate,
                track.Comment,
                Opportunity = new
                {
                    track.Opportunity.OpportunityID
                },
                Client = new
                {
                    track.Opportunity.Client.Name,
                    track.Opportunity.Client.PhoneNumber
                },
                OrderStatus = new
                {
                    track.OpportunityStatus.OpportunityStatusID,
                    track.OpportunityStatus.Name
                }
            }).ToListAsync();
            return lista;
        }
    }
}