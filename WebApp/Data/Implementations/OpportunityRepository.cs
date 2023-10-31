using WebApp.Models;
namespace WebApp.Data
{
    public class OpportunityRepository : Repository<Opportunity>, IOpportunityRepository
    {
        public OpportunityRepository(ApplicationDbContext context) : base(context) { }
    }
}