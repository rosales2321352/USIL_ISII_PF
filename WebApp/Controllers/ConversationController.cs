using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/conversations")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly IConversationService _conversationService;

        public ConversationController(IConversationService conversationService)
        {
            _conversationService = conversationService;
        }

        [HttpGet]
        [Route("messages/{id:int}")]
        public async Task<IActionResult> GetCompleteConversation(int id)
        {
            var conversation = await _conversationService.GetCompleteConversation(id);

            ApiListResponse<object> response = new(conversation, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }
    }
}