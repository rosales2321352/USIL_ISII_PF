using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.Events
            .Include(e => e.EventType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Select(e => new
            {
                e.EventID,
                e.Title,
                e.Description,
                e.DateAssigned,
                EventType = e.EventType.Name,
                ClientName = e.Client.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("ListaCliente/{id:int}")]
        public async Task<IActionResult> GetListByClient(int id)
        {
            var listByClient = await _context.Events
            .Include(e => e.EventType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Where(e => e.ClientID == id)
            .Select(e => new
            {
                e.EventID,
                e.Title,
                e.Description,
                e.DateAssigned,
                EventType = e.EventType.Name,
                ClientName = e.Client.Name
            })
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, listByClient);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var eventDetail = await _context.Events
            .Include(e => e.EventType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Select(e => new
            {
                e.EventID,
                e.Title,
                e.Description,
                e.DateAssigned,
                EventType = e.EventType.Name,
                ClientName = e.Client.Name
            })
            .FirstOrDefaultAsync(e => e.EventID == id);

            return StatusCode(StatusCodes.Status200OK, eventDetail);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> NewEvent([FromBody] EventView request)
        {
            Event newEvent = new()
            {
                Title = request.Title,
                EventTypeID = request.EventTypeID,
                DateAssigned = request.DateAssigned,
                Description = request.Description,
                SellerID = 1,
                ClientID = request.ClientID
            };

            await _context.Events.AddAsync(newEvent);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] EventUpdate request)
        {
            var eventUpdate = await _context.Events.FindAsync(request.EventID);

            if (eventUpdate != null)
            {
                eventUpdate.Title = request.Title;
                eventUpdate.Description = request.Description;
                eventUpdate.DateAssigned = request.DateAssigned;
                eventUpdate.EventTypeID = request.EventTypeID;

                _context.Events.Update(eventUpdate);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Not Event Found with that ID");
            }


        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var eventDelete = await _context.Events.FindAsync(id);

            if (eventDelete != null)
            {
                _context.Events.Remove(eventDelete);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Event Found with that ID");
        }
    }
}
