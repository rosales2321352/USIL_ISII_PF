using WebApp.Models;
namespace WebApp.Data
{
    public interface IOpportunityRepository : IRepository<Opportunity>
    {
        Task<IEnumerable<object>> GetAllOpportunities();
        Task<object> GetOpportunityById(int id);
        Task<IEnumerable<object>> GetOpportunityByStatus(int id);
    }
}