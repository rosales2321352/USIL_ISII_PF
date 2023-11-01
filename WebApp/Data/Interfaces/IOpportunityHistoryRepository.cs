using WebApp.Models;
namespace WebApp.Data
{
    public interface IOpportunityHistoryRepository : IRepository<OpportunityStatusHistory>
    {
        Task<IEnumerable<object>> GetOpportunitiesHistory(int id);
    }
}
