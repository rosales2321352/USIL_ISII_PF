using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/event-types")]
    [ApiController]
    public class EventTypeController : ControllerBase
    {
        private readonly IEventTypeService _eventTypeService;
        public EventTypeController(IEventTypeService eventTypeService)
        {
            _eventTypeService = eventTypeService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEventTypes()
        {
            var eventTypes = await _eventTypeService.GetAllEventTypes();
            ApiListResponse<object> apiListResponse = new(eventTypes, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, apiListResponse);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> NewEventType([FromBody] EventTypeRequest request)
        {
            var eventType = await _eventTypeService.CreateEventType(request);
            ApiSingleObjectResponse<object> response = new(eventType, StatusCodes.Status200OK, "Tipo de Evento Creado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EventTypeRequest request)
        {
            var eventType = await _eventTypeService.EditEventType(request);
            ApiSingleObjectResponse<object> response = new(eventType, StatusCodes.Status200OK, "Tipo de Evento Actualizado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEventType([FromBody] EventTypeDelete request)
        {
            await _eventTypeService.DeleteEventType(request.EventTypeID);
            return StatusCode(StatusCodes.Status200OK, "Tipo de Evento Eliminado");
        }
    }
}
