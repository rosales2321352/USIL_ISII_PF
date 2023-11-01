using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OpportunityStatusService : Service<OpportunityStatus>, IOpportunityStatusService
    {
        private readonly IOpportunityStatusRepository _opportunityStatusRepository;
        public OpportunityStatusService(IOpportunityStatusRepository repository) : base(repository) 
        { 
            _opportunityStatusRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllOpportunityStatuses()
        {
            return await _opportunityStatusRepository.GetAllOpportunityStatuses();
        }

        public async Task CreateOpportunityStatus(OpportunityStatusRequest request)
        {
            OpportunityStatus opportunityStatus = new ()
            {
                Name = request.Name
            };

            await _repository.Add(opportunityStatus);
        }

        public async Task EditOpportunityStatus(OpportunityStatusRequest request)
        {
            int statusId = request.StatusID ?? 0;
            var opportunityStatus = await _repository.GetById(statusId);

            opportunityStatus.Name = request.Name;

            await _repository.Update(opportunityStatus);
        }
    }
}