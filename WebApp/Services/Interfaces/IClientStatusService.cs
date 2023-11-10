using WebApp.Models;
namespace WebApp.Services
{
    public interface IClientStatusService: IService<ClientStatus>
    {
        Task<IEnumerable<object>> GetAllClientStatus();
        Task CreateClientStatus(ClientStatusRequest request);
        Task EditClientStatus(ClientStatusRequest request);
    }
}