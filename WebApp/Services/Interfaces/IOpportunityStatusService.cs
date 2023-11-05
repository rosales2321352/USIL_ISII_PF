using WebApp.Models;
namespace WebApp.Services
{
    public interface IOpportunityStatusService : IService<OpportunityStatus>
    {
        Task<IEnumerable<object>> GetAllOpportunityStatuses();
        Task CreateOpportunityStatus(OpportunityStatusRequest request);
        Task EditOpportunityStatus(OpportunityStatusRequest request);
    }
}