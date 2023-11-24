using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class EventTypeService : Service<EventType>, IEventTypeService
    {
        private readonly IEventTypeRepository _eventTypeRepository;
        public EventTypeService(IEventTypeRepository repository) : base(repository)
        {
            _eventTypeRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllEventTypes()
        {
            return await _eventTypeRepository.GetAllEventTypes();
        }
        public async Task<object> CreateEventType(EventTypeRequest request)
        {
            EventType eventType = new()
            {
                Name = request.Name
            };

            await _repository.Add(eventType);
            request.TypeID = eventType.EventTypeID;
            return request;
        }
        public async Task<object> EditEventType(EventTypeRequest request)
        {
            int statusId = request.TypeID ?? 0;
            var eventType = await _repository.GetById(statusId);

            eventType.Name = request.Name;

            await _repository.Update(eventType);
            return request;
        }

        public async Task DeleteEventType(int eventTypeID)
        {
            var eventType = await _repository.GetById(eventTypeID);

            eventType.IsAvailable = false;

            await _repository.Update(eventType);
        }
    }
}