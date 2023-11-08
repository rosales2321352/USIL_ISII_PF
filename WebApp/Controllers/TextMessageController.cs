using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/texts")]
    [ApiController]
    public class TextMessageController : ControllerBase
    {
        private readonly ITextMessageService _textMessageService;

        public TextMessageController(ITextMessageService textMessageService)
        {
            _textMessageService = textMessageService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> SendMessage(TextMessageRequest request)
        {
            await _textMessageService.SendMessage(request);
            return Ok();
        }

    }
}