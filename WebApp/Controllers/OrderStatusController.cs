using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.OrderStatuses.Select(e => new 
            {
                Id = e.OrderStatusID,
                e.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> NewStatus([FromBody] string newName)
        {
            OrderStatus newStatus = new()
            {
                Name = newName
            };
            
            await _context.OrderStatuses.AddAsync(newStatus);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] OrderStatus request)
        {
            _context.OrderStatuses.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //TODO Verificar si se puede eliminar estados
        /*
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            OrderStatus? order = await _context.OrderStatuses.FindAsync(id);

            if (order != null)
            {
                _context.OrderStatuses.Remove(order);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
        }*/
    }
}
