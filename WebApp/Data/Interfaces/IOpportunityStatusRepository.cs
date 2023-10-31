using WebApp.Models;
namespace WebApp.Data
{
    public interface IOpportunityStatusRepository : IRepository<OpportunityStatus>
    {
        Task<IEnumerable<object>> GetAllOpportunityStatuses();
    }
}