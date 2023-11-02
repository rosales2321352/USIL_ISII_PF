using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Services;

namespace WebApp.Controllers
{

    [Route("api/opportunity-status-history")]
    [ApiController]
    public class OpportunityHistoryController : ControllerBase
    {
        private readonly IOpportunityHistoryService _opportunityHistoryService;
        public OpportunityHistoryController(IOpportunityHistoryService orderHistoryService)
        {
            _opportunityHistoryService = orderHistoryService;
        }

        [HttpGet]
        [Route("all/{id:int}")]
        public async Task<IActionResult> GetOrdersHistory(int id)
        {
            var lista = await _opportunityHistoryService.GetAllHistory(id);

            ApiListResponse<object> apiResponse = new(lista, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, apiResponse);
        }
    }
}
