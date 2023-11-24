using WebApp.Models;
namespace WebApp.Services
{
    public interface IOpportunityService : IService<Opportunity>
    {
        Task<IEnumerable<object>> GetAllOpportunities();
        Task<object> GetOpportunityById(int id);
        Task<IEnumerable<object>> GetOpportunityByStatus(int id);
        Task<object> CreateOpportunity(OpportunityRequest request);
        Task<object> UpdateOpportunityStatus(OpportunityStatusUpdate request);
        Task DeleteOpportunity(int id);
    }
}