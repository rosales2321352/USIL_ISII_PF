using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/opportunities")]
    [ApiController]
    public class OpportunityController : ControllerBase
    {
        private readonly IOpportunityService _opportunityService;

        public OpportunityController(IOpportunityService opportunityService)
        {
            _opportunityService = opportunityService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetOpportunities()
        {
            var opportunities = await _opportunityService.GetAllOpportunities();

            ApiListResponse<object> apiListResponse = new(opportunities, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, apiListResponse);
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetOpportunityById(int id)
        {
            var opportunity = await _opportunityService.GetOpportunityById(id);

            ApiSingleObjectResponse<object> response = new(opportunity, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("by-status/{id:int}")]
        public async Task<IActionResult> GetOpportunitiesByStatus(int id)
        {
            var opportunities = await _opportunityService.GetOpportunityByStatus(id);

            ApiListResponse<object> response = new(opportunities, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);

        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOpportunity([FromBody] OpportunityRequest request)
        {
            await _opportunityService.CreateOpportunity(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateOpportunityStatus([FromBody] OpportunityStatusUpdate request)
        {
            await _opportunityService.UpdateOpportunityStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //TODO eliminacion
        
    }
}
