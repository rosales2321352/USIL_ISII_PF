using WebApp.Models;
namespace WebApp.Services
{
    public interface IOpportunityStatusService : IService<OpportunityStatus>
    {
        Task<IEnumerable<object>> GetAllOpportunityStatuses();
        Task<object> CreateOpportunityStatus(OpportunityStatusRequest request);
        Task<object> EditOpportunityStatus(OpportunityStatusRequest request);
        Task DeleteOpportunityStatus(int id);
    }
}