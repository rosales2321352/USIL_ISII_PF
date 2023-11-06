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
            await _clientStatusService.CreateClientStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditClientStatus([FromBody] ClientStatusRequest request)
        {
            await _clientStatusService.EditClientStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
