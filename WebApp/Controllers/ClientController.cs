using Microsoft.AspNetCore.Mvc;
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

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
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
            ApiSingleObjectResponse<object> response = new(client, StatusCodes.Status200OK, "Cliente Encontrado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("edit")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientUpdate request)
        {
            var client = await _clientService.EditClient(request);
            ApiSingleObjectResponse<object> response = new(client, StatusCodes.Status200OK, "Cliente Actualizado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

    }
}
