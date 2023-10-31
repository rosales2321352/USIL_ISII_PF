using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OpportunityService : Service<Opportunity>, IOpportunityService
    {
        public OpportunityService(IOpportunityRepository repository) : base(repository) 
        { 
            
        }
    }
}