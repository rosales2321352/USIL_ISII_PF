using WebApp.Models;
namespace WebApp.Data
{
    public interface IClientRepository : IRepository<Client>
    {
        Task<IEnumerable<object>> GetAllClients();
        Task<Client?> GetClientByWhatsappId(string id);
        Task<IEnumerable<object>> GetClientsWithName();
        Task<object?> GetClientDetail(int id);
    }
}