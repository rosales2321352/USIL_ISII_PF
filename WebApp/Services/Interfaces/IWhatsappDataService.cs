using WebApp.Models;
using WebApp.Data;
namespace WebApp.Services
{
    public interface IWhatsappDataService : IService<WhatsappData>
    {
        Task CreateWhatsappData(WhatsappData data);
        Task CreateWhatsappDataFromJSON(WebHookResponseModel request);
    }
}