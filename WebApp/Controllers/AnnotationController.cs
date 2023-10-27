using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class AnnotationController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AnnotationController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.Annotations
            .Include(e => e.AnnotationType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Select(e => new
            {
                e.AnnotationID,
                e.Description,
                e.Title,
                AnnotationType = e.AnnotationType.Name,
                ClientName = e.Client.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("ListaCliente/{id:int}")]
        public async Task<IActionResult> GetListByClient(int id)
        {
            var listByClient = await _context.Annotations
            .Include(e => e.AnnotationType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Where(e => e.ClientID == id)
            .Select(e => new
            {
                e.AnnotationID,
                e.Description,
                e.Title,
                AnnotationType = e.AnnotationType.Name,
                ClientName = e.Client.Name
            })
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, listByClient);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var annotation = await _context.Annotations
            .Include(e => e.AnnotationType)
            .Include(e => e.Client)
            .AsNoTracking()
            .Select(e => new
            {
                e.AnnotationID,
                e.Description,
                e.Title,
                AnnotationType = e.AnnotationType.Name,
                ClientName = e.Client.Name
            })
            .FirstOrDefaultAsync(e => e.AnnotationID == id);

            return StatusCode(StatusCodes.Status200OK, annotation);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> NewAnnotation([FromBody] AnnotationView request)
        {
            Annotation newAnnotation = new()
            {
                Title = request.Title,
                ClientID = request.ClientID,
                Description = request.Description,
                AnnotationTypeID = request.AnnotationTypeID,
                SellerID = 1
            };

            await _context.Annotations.AddAsync(newAnnotation);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] AnnotationUpdate request)
        {
            var annotation = await _context.Annotations.FindAsync(request.AnnotationID);

            if (annotation != null)
            {
                annotation.Title = request.Title;
                annotation.Description = request.Description;
                annotation.AnnotationTypeID = request.AnnotationTypeID;

                _context.Annotations.Update(annotation);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Not Annnotation Found with that ID");
            }


        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var order = await _context.Annotations.FindAsync(id);

            if (order != null)
            {
                _context.Annotations.Remove(order);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
        }
    }
}
