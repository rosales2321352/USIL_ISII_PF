using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class ClientStatusService : Service<ClientStatus>, IClientStatusService
    {
        private readonly IClientStatusRepository _clientStatusRepository;

        public ClientStatusService(IClientStatusRepository repository) : base(repository)
        {
            _clientStatusRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllClientStatus()
        {
            return await _clientStatusRepository.GetAllClientStatuses();
        }
        public async Task<object> CreateClientStatus(ClientStatusRequest request)
        {
            ClientStatus clientStatus = new()
            {
                Name = request.Name
            };
            await _repository.Add(clientStatus);
            request.StatusID = clientStatus.ClientStatusID;
            return request;
        }
        public async Task<object> EditClientStatus(ClientStatusRequest request)
        {
            int statusId = request.StatusID ?? 0;
            var clientStatus = await _repository.GetById(statusId);

            clientStatus.Name = request.Name;

            await _repository.Update(clientStatus);
            return request;
        }

        public async Task DeleteClientStatus(ClientStatusDelete request)
        {
            int statusId = request.ClientStatusID;
            var clientStatus = await _repository.GetById(statusId);

            clientStatus.IsAvailable = false;

            await _repository.Update(clientStatus);
        }
    }
}