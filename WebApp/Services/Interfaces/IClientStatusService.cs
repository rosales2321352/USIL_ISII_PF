using WebApp.Models;
namespace WebApp.Services
{
    public interface IClientStatusService: IService<ClientStatus>
    {
        Task<IEnumerable<object>> GetAllClientStatus();
        Task<object> CreateClientStatus(ClientStatusRequest request);
        Task<object> EditClientStatus(ClientStatusRequest request);
        Task DeleteClientStatus(ClientStatusDelete request);
    }
}