using WebApp.Models;
namespace WebApp.Data
{
    public interface IClientStatusRepository : IRepository<ClientStatus>
    {
        Task<IEnumerable<object>> GetAllClientStatuses();
    }
}