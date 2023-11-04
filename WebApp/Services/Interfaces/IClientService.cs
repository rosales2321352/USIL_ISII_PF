using WebApp.Models;
namespace WebApp.Services
{
    public interface IClientService: IService<Client>
    {
        Task<IEnumerable<object>> GetAllClients();
        Task CreateClient(ClientRequest request);
        Task EditClient(ClientUpdate request);
    }
}