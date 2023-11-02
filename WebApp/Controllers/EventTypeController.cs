using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
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
            await _eventTypeService.CreateEventType(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] EventTypeRequest request)
        {
            await _eventTypeService.EditEventType(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
