using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly IEventService _eventService;

        public EventController(IEventService eventService)
        {
            _eventService = eventService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllEvents()
        {
            var list = await _eventService.GetAllEvents();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("by-client/{id:int}")]
        public async Task<IActionResult> GetAllEventsByClient(int id)
        {
            var list = await _eventService.GetAllEventsByClient(id);
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetEventDetail(int id)
        {
            var eve = await _eventService.GetEventDetail(id);
            ApiSingleObjectResponse<object> response = new(eve, StatusCodes.Status200OK, "Evento Encontrado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequest request)
        {
            var eve = await _eventService.CreateEvent(request);
            ApiSingleObjectResponse<object> response = new(eve, StatusCodes.Status200OK, "Evento Creado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditEvent([FromBody] EventUpdate request)
        {
            var eve = await _eventService.EditEvent(request);
            ApiSingleObjectResponse<object> response = new(eve, StatusCodes.Status200OK, "Evento Actualizado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEvent([FromBody] EventDelete request)
        {
            await _eventService.DeleteEvent(request);
            return StatusCode(StatusCodes.Status200OK, "Evento Eliminado");
        }
    }
}
