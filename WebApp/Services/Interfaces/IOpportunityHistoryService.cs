using WebApp.Models;
namespace WebApp.Services
{
    public interface IOpportunityHistoryService : IService<OpportunityStatusHistory>
    {
        Task<IEnumerable<object>> GetAllHistory(int id);
    }
}