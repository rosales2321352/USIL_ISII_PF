using WebApp.Models;
namespace WebApp.Data
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<object>> GetAllClients();
        Task<Client> GetClient(string id);
    }
}