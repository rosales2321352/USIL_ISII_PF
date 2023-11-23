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

        public async Task CreateWhatsappDataFromJSON(WebHookResponseModel request)
        {
             WhatsappData whatsappData = new()
                {
                    WhatsappID = request.Entry[0].Changes[0].Value.Contacts[0].Wa_id,
                    PhonenumberCode = request.Entry[0].Changes[0].Value.Messages[0].From,
                    WhatsappName = request.Entry[0].Changes[0].Value.Contacts[0].Profile.Name
                };
            await _repository.Add(whatsappData);
        }
    }
}