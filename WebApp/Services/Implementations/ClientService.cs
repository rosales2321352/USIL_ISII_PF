using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class ClientService: Service<Client>, IClientService
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
        public async Task CreateClient(ClientRequest request)
        {
            Client client = new()
            {
                PhoneNumber = request.PhoneNumber,
                WhatsappID = request.WhatsappID
            };
            
            await _repository.Add(client);
        }
        public async Task EditClient(ClientUpdate request)
        {
            Client client = await _clientRepository.GetClient(request.WhatsappID);
            
            client.Name = request.Name;
            client.PhoneNumber = request.PhoneNumber;
            client.CompanyID = request.CompanyID;
            client.Email = request.Email;

            await _repository.Update(client);
        }

    }
}