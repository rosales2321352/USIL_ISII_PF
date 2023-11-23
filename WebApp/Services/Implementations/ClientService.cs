using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class ClientService : Service<Client>, IClientService
    {
        private readonly IClientRepository _clientRepository;
        public ClientService(IClientRepository repository) : base(repository)
        {
            _clientRepository = repository;
        }
        public async Task<IEnumerable<object>> GetAllClients()
        {
            return await _clientRepository.GetAllClients();
        }
        public async Task<Client?> GetClientByWhatsappId(string whatsappID)
        {
            return await _clientRepository.GetClientByWhatsappId(whatsappID);
        }
        public async Task<IEnumerable<object>> GetAllClientsWithName()
        {
            return await _clientRepository.GetClientsWithName();
        }
        public async Task<object?> GetClientDetail(int id)
        {
            return await _clientRepository.GetClientDetail(id);
        }
        public async Task<int> CreateClient(ClientRequest request)
        {
            Client client = new()
            {
                PhoneNumber = request.PhoneNumber,
                WhatsappID = request.WhatsappID,
                ClientStatusID = 1,
                SellerID = 1
            };

            await _repository.Add(client);
            return client.PersonID;
        }
        public async Task<int> CreateClientFromJSON(WebHookResponseModel request)
        {
            Client client = new()
            {
                PhoneNumber = request.Entry[0].Changes[0].Value.Messages[0].From,
                WhatsappID = request.Entry[0].Changes[0].Value.Contacts[0].Wa_id,
                ClientStatusID = 1,
                SellerID = 1
            };

            await _repository.Add(client);
            return client.PersonID;
        }
        public async Task EditClient(ClientUpdate request)
        {
            Client client = await _clientRepository.GetById(request.PersonID);

            client.Name = request.Name;
            client.PhoneNumber = request.PhoneNumber;
            client.CompanyID = request.CompanyID;
            client.Email = request.Email;

            await _repository.Update(client);
        }

    }
}