using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/opportunitystatus")]
    [ApiController]
    public class OpportunityStatusController : ControllerBase
    {
        private readonly IOpportunityStatusService _opportunityStatusService;

        public OpportunityStatusController(IOpportunityStatusService opportunityStatusService)
        {
            _opportunityStatusService = opportunityStatusService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetOpportunitiesStatuses()
        {
            var opportunityStatuses = await _opportunityStatusService.GetAllOpportunityStatuses();
            ApiListResponse<object> apiResponse = new(opportunityStatuses, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, apiResponse);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOpportunityStatus([FromBody] OpportunityStatusRequest request)
        {
            await _opportunityStatusService.CreateOpportunityStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] OpportunityStatusRequest request)
        {
            await _opportunityStatusService.EditOpportunityStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }



        //TODO Eliminacion logica y fisica de estados.
    }
}
