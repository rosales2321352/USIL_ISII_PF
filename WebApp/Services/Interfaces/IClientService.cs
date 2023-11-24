using WebApp.Models;
namespace WebApp.Services
{
    public interface IClientService: IService<Client>
    {
        Task<IEnumerable<object>> GetAllClients();
        Task<Client?> GetClientByWhatsappId(string whatsappID);
        Task<IEnumerable<object>> GetAllClientsWithName();
        Task<object?> GetClientDetail(int id);
        Task<int> CreateClient(ClientRequest request);
        Task<int> CreateClientFromJSON(WebHookResponseModel request);
        Task<object> EditClient(ClientUpdate request);
    }
}