using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/clients")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly ApplicationDbContext _context;

        public ClientController(ApplicationDbContext context, IClientService clientService)
        {
            _clientService = clientService;
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
        [Route("all")]
        public async Task<IActionResult> GetClients()
        {
            var list = await _clientService.GetAllClients();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("contacts")]
        public async Task<IActionResult> GetClientsWithName()
        {
            var list = await _clientService.GetAllClientsWithName();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetClientDetail(int id)
        {
            var client = await _clientService.GetClientDetail(id);
            ApiSingleObjectResponse<object> response = new(client, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        /*[HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateClient([FromBody] ClientRequest request)
        {
            await _clientService.CreateClient(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }*/

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientUpdate request)
        {
            await _clientService.EditClient(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

    }
}
