using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/client-status")]
    [ApiController]
    public class ClientStatusController : ControllerBase
    {
        private readonly IClientStatusService _clientStatusService;
        public ClientStatusController(IClientStatusService clientStatusService)
        {
            _clientStatusService = clientStatusService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllClientStatus()
        {
            var list = await _clientStatusService.GetAllClientStatus();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateClientStatus([FromBody] ClientStatusRequest request)
        {
            var client = await _clientStatusService.CreateClientStatus(request);
            ApiSingleObjectResponse<object> response = new(client, StatusCodes.Status200OK, "Estado de Cliente Creado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditClientStatus([FromBody] ClientStatusRequest request)
        {
            var client = await _clientStatusService.EditClientStatus(request);
            ApiSingleObjectResponse<object> response = new(client, StatusCodes.Status200OK, "Estado de Cliente Creado");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody]ClientStatusDelete request)
        {
            await _clientStatusService.DeleteClientStatus(request);
            return StatusCode(StatusCodes.Status200OK, "Estado de Cliente Eliminado");
        }
    }
}
