using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CompanyController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            List<CompanyView> lista = await _context.Companies.Select(b => new CompanyView
            {
                Name = b.Name,
                Address = b.Address,
                Email = b.Email
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
           Company? lastCompany = await _context.Companies.FindAsync(id);

            return StatusCode(StatusCodes.Status200OK, lastCompany);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] CompanyView request)
        {
            Company? lastCompany = await _context.Companies.OrderByDescending(e => e.CompanyID).FirstOrDefaultAsync();
            if (lastCompany != null)
            {

                int lastID = lastCompany.CompanyID;
                Company newCompany = new()
                {
                    Name = request.Name,
                    Email = request.Email,
                    Address = request.Address,
                    CompanyID = lastID + 1
                };

                await _context.Companies.AddAsync(newCompany);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Valid Company");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] Company request)
        {
            _context.Companies.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Company? company = await _context.Companies.FindAsync(id);

            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Company Found with that ID");
        }
    }
}
