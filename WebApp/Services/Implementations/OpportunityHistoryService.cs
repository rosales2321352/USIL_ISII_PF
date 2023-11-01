using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OpportunityHistoryService : Service<OpportunityStatusHistory>, IOpportunityHistoryService
    {
        private readonly IOpportunityHistoryRepository _opportunityHistoryRepository;
        public OpportunityHistoryService(IOpportunityHistoryRepository repository) : base(repository) 
        { 
            _opportunityHistoryRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllHistory(int id)
        {
            return await _opportunityHistoryRepository.GetOpportunitiesHistory(id);
        } 
    }
}