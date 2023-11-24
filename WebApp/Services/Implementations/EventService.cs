using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class EventService : Service<Event>, IEventService
    {
        private readonly IEventRepository _eventRepository;
        public EventService(IEventRepository repository) : base(repository)
        {
            _eventRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllEvents()
        {

            return await _eventRepository.GetAllEvents();
        }

        public async Task<object> GetEventDetail(int id)
        {
            return await _eventRepository.GetEventDetail(id);
        }

        public async Task<IEnumerable<object>> GetAllEventsByClient(int id)
        {
            return await _eventRepository.GetAllEventsByClient(id);
        }
        public async Task<object> CreateEvent(EventRequest request)
        {
            Event eve = new()
            {
                Title = request.Title,
                Description = request.Description,
                EventTypeID = request.EventTypeID,
                SellerID = request.SellerID,
                ClientID = request.ClientID,
                DateAssigned = request.DateAssigned,
                BeginTime = request.BeginTime,
                EndTime = request.EndTime
            };

            await _repository.Add(eve);
            request.EventID = eve.EventID;

            return request;
        }

        public async Task<object> EditEvent(EventUpdate request)
        {
            var eve = await _repository.GetById(request.EventID);

            eve.Title = request.Title;
            eve.Description = request.Description;
            eve.EventTypeID = request.EventTypeID;
            eve.DateAssigned = request.DateAssigned;
            eve.BeginTime = request.BeginTime;
            eve.EndTime = request.EndTime;

            await _repository.Update(eve);
            return request;
        }

        public async Task DeleteEvent(EventDelete request)
        {
            var eve = await _repository.GetById(request.EventID);

            await _repository.Delete(eve);
        }
    }
}