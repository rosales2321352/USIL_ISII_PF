using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IEventService _eventService;

        public EventController(IEventService eventService, ApplicationDbContext context)
        {
            _eventService = eventService;
            _context = context;
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
            ApiSingleObjectResponse<Annotation> response = new(eve, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEvent([FromBody] EventRequest request)
        {
            await _eventService.CreateEvent(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditEvent([FromBody] EventUpdate request)
        {
            await _eventService.EditEvent(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> DeleteEvent([FromBody] EventDelete request)
        {
            await _eventService.DeleteEvent(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
