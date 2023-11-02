using WebApp.Models;
namespace WebApp.Services
{
    public interface IOpportunityService : IService<Opportunity>
    {
        Task<IEnumerable<object>> GetAllOpportunities();
        Task<object> GetOpportunityById(int id);
        Task<IEnumerable<object>> GetOpportunityByStatus(int id);
        Task CreateOpportunity(OpportunityRequest request);
        Task UpdateOpportunityStatus(OpportunityStatusUpdate request);
    }
}