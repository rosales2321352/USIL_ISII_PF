using System.Net;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApp.Services;
namespace WebApp.Controllers
{
    [Route("api/whatsapp")]
    [ApiController]
    public class WhatsappController : ControllerBase
    {
        private readonly ITextMessageService _textMessageService;

        public WhatsappController(ITextMessageService textMessageService)
        {
            _textMessageService = textMessageService;
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
            Console.WriteLine(request.ToString());

            await _textMessageService.CreateMessage(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}