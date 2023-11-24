using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OpportunityService : Service<Opportunity>, IOpportunityService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOpportunityRepository _opportunityRepository;
        public OpportunityService(IServiceProvider serviceProvider, IOpportunityRepository repository) : base(repository)
        {
            _serviceProvider = serviceProvider;
            _opportunityRepository = repository;
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

        public async Task<object> CreateOpportunity(OpportunityRequest request)
        {
            Opportunity opportunity = new()
            {
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                ClientID = request.ClientID,
                SellerID = 1,
                OpportunityStatusID = 1
            };

            await _repository.Add(opportunity);

            var response = new
            {
                opportunity.OpportunityID,
                opportunity.CreationDate,
                opportunity.ClientID,
                opportunity.SellerID,
                opportunity.OpportunityStatusID
            };

            return response;
        }

        public async Task<object> UpdateOpportunityStatus(OpportunityStatusUpdate request)
        {
            IOpportunityHistoryService opportunityHistory = _serviceProvider.GetRequiredService<IOpportunityHistoryService>();
            var opportunity = await _repository.GetById(request.OpportunityID);
            opportunity.OpportunityStatusID = request.OpportunityStatusID;

            await opportunityHistory.CreateOpportunityHistory(request);

            await _repository.Update(opportunity);

            var response = new
            {
                opportunity.OpportunityID,
                opportunity.CreationDate,
                opportunity.ClientID,
                opportunity.SellerID,
                opportunity.OpportunityStatusID
            };

            return response;
        }

        public async Task DeleteOpportunity(int id)
        {
            var opportunity = await _repository.GetById(id);
            opportunity.IsAvailable = false;
            await _repository.Update(opportunity);
        }

    }
}