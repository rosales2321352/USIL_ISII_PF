using WebApp.Models;
using WebApp.Data;
namespace WebApp.Services
{
    public class WhatsappDataService : Service<WhatsappData>, IWhatsappDataService
    {
        public WhatsappDataService(IWhatsappDataRepository repository) : base(repository)
        {
            
        }

        public async Task CreateWhatsappData(WhatsappData data)
        {
            await _repository.Add(data);
        }
    }
}