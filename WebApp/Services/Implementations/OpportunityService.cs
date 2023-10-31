using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OpportunityService : Service<Opportunity>, IOpportunityService
    {
        private readonly IOpportunityRepository _opportunityRepository;
        private readonly IOpportunityHistoryRepository _opportunityHistoryRepository;
        public OpportunityService(IOpportunityRepository repository,IOpportunityHistoryRepository historyRepository) : base(repository) 
        { 
            _opportunityRepository = repository;
            _opportunityHistoryRepository = historyRepository;

        }

        public async Task<IEnumerable<object>> GetAllOpportunities()
        {

            return await _opportunityRepository.GetAllOpportunities();
        }

        public async Task<object> GetOpportunityById(int id)
        {
            return await _opportunityRepository.GetOpportunityById(id);
        }

        public async Task<IEnumerable<object>> GetOpportunityByStatus(int id)
        {
            return await _opportunityRepository.GetOpportunityByStatus(id);
        }

        public async Task CreateOpportunity(OpportunityRequest request)
        {
            Opportunity opportunity = new()
            {
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                ClientID = request.ClientID
            };

            await _repository.Add(opportunity);
        }

        public async Task UpdateOpportunityStatus(OpportunityStatusUpdate request)
        {
            var opportunity = await _repository.GetById(request.OpportunityID);
            opportunity.OpportunityStatusID = request.OpportunityStatusID;

            OpportunityStatusHistory opportunityHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OpportunityID = request.OpportunityID,
                OpportunityStatusHistoryID = request.OpportunityStatusID,
                Comment = request.Comment
            };

            await _opportunityRepository.UpdateOpportunityStatus(opportunity,opportunityHistoryRegister, _opportunityHistoryRepository);
        }

    }
}