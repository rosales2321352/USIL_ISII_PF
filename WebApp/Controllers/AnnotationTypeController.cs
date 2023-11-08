using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/annotationtypes")]
    [ApiController]
    public class AnnotationTypeController : ControllerBase
    {
        private readonly IAnnotationTypeService _annotatitonTypeService;

        public AnnotationTypeController(IAnnotationTypeService annotatitonTypeService)
        {
            _annotatitonTypeService = annotatitonTypeService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAnnotationTypes()
        {
            var annotationTypes = await _annotatitonTypeService.GetAllAnnotationTypes();
            ApiListResponse<object> apiListResponse = new(annotationTypes, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, apiListResponse);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAnnotationType([FromBody] AnnotationTypeRequest request)
        {
            await _annotatitonTypeService.CreateAnnotationType(request);

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] AnnotationTypeRequest request)
        {
            await _annotatitonTypeService.EditAnnotationType(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}
