using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/opportunity-status")]
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
            var opportunityStatus = await _opportunityStatusService.CreateOpportunityStatus(request);
            ApiSingleObjectResponse<object> response = new(opportunityStatus, StatusCodes.Status200OK, "Estado de Oportunidad Creada");
            return StatusCode(StatusCodes.Status200OK, response);

        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] OpportunityStatusRequest request)
        {
            var opportunityStatus = await _opportunityStatusService.EditOpportunityStatus(request);
            ApiSingleObjectResponse<object> response = new(opportunityStatus, StatusCodes.Status200OK, "Estado de Oportunidad Actualizada");
            return StatusCode(StatusCodes.Status200OK, response);
        }
        
        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] OpportunityStatusDelete request)
        {
            await _opportunityStatusService.DeleteOpportunityStatus(request.OpportunityStatusID);
            return StatusCode(StatusCodes.Status200OK, "Estado de Oportunidad Eliminada");
        }
    }
}
