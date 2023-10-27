using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnotationTypeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnotationTypeController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.AnnotationTypes.Select(e => new 
            {
                Id = e.AnnotationTypeID,
                e.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] string newName)
        {
            AnnotationType newStatus = new()
            {
                Name = newName
            };
            
            await _context.AnnotationTypes.AddAsync(newStatus);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] AnnotationType request)
        {
            _context.AnnotationTypes.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
