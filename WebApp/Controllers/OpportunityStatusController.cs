using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunityStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OpportunityStatusController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.OpportunityStatuses.Select(e => new 
            {
                Id = e.OpportunityStatusID,
                e.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] string newName)
        {
            OpportunityStatus newStatus = new()
            {
                Name = newName
            };
            
            await _context.OpportunityStatuses.AddAsync(newStatus);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] OpportunityStatus request)
        {
            _context.OpportunityStatuses.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //TODO Verificar si se puede eliminar estados
        
        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            OpportunityStatus? order = await _context.OpportunityStatuses.FindAsync(id);

            if (order != null)
            {
                _context.OpportunityStatuses.Remove(order);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
        }
    }
}
