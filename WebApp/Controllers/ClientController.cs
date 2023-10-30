using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> TemporalWhatssap(string number)
        {
            var index = _context.WhatsappDatas.ToList().Count + 1;

            WhatsappData whatsappDummie = new()
            {
                WhatsappID = index.ToString(),
                PhonenumberCode = number,
                WhatsappName = "testing Name",
            };

            await _context.WhatsappDatas.AddAsync(whatsappDummie);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetClients()
        {
            var lista = await _context.Clients
            .Include(e => e.ClientStatus)
            .Include(e => e.Company)
            .AsNoTracking()
            .Select(e => new
            {
                e.PersonID,
                e.Name,
                e.PhoneNumber,
                ClientStatus = e.ClientStatus.Name,
                CompanyAddress = e.Company.Address
            })
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetClientDetail(int id)
        {
            var lista = await _context.Clients
            .Include(e => e.ClientStatus)
            .Include(e => e.Company)
            .AsNoTracking()
            .Select(e => new
            {
                e.PersonID,
                e.Name,
                e.PhoneNumber,
                e.Email,
                ClientStatus = e.ClientStatus.Name,
                CompanyName = e.Company.Name,
                CompanyAddress = e.Company.Address

            })
            .FirstOrDefaultAsync(e => e.PersonID == id);

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> NewClient([FromBody] NewClient newClient)
        {
            await TemporalWhatssap(newClient.Phonenumber);

            int whatsIdTemp = _context.WhatsappDatas.ToList().Count;
            Client client = new()
            {
                Name = newClient.Name,
                PhoneNumber = newClient.Phonenumber,
                WhatsappID = whatsIdTemp.ToString(),
                Email = newClient.Email,
                SellerID = 1,
                ClientStatusID = 1,
                CompanyID = newClient.CompanyID
            };

            await _context.Clients.AddAsync(client);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> EditClient([FromBody] UpdateClient request)
        {
            var client = await _context.Clients.FindAsync(request.PersonID);

            if (client != null)
            {

                client.Name = request.Name;
                client.PhoneNumber = request.Phonenumber;
                client.Email = request.Email;
                client.ClientStatusID = request.ClientStatusID;

                _context.Clients.Update(client);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "No Client with that ID");
            }


        }

    }
}
