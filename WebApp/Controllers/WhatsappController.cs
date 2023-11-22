using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp.Services;
using Microsoft.AspNetCore.SignalR;
using WebApp.Hubs;
namespace WebApp.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        private readonly ITextMessageService _textMessageService;
        private readonly IHubContext<ChatHub> _hubContext;
        public WhatsappController(ITextMessageService textMessageService, IHubContext<ChatHub> hubContext)
        {
            _textMessageService = textMessageService;
            _hubContext = hubContext;
        }


        [HttpGet]
        [Route("webhook")]
        public string Webhook(
            [FromQuery(Name = "hub.mode")] string mode,
            [FromQuery(Name = "hub.challenge")] string challenge,
            [FromQuery(Name = "hub.verify_token")] string verify_token
        )
        {
            if (verify_token.Equals("hola"))
            {
                return challenge;
            }
            else
            {
                return "";
            }
        }

        [HttpPost]
        [Route("webhook")]
        public async Task<IActionResult> EntryMessage([FromBody] WebHookResponseModel request)
        {
            var message = await _textMessageService.CreateMessage(request);
            await _hubContext.Clients.All.SendAsync("ReceiveMessage", message.WhatsappID, message.Text);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}