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
            var annotationType = await _annotatitonTypeService.CreateAnnotationType(request);
            ApiSingleObjectResponse<object> response = new(annotationType, StatusCodes.Status201Created, "Tipo de Anotacion Creada");
            return StatusCode(StatusCodes.Status201Created, response);

        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] AnnotationTypeRequest request)
        {
            var annotationType = await _annotatitonTypeService.EditAnnotationType(request);
            
            ApiSingleObjectResponse<object> response = new(annotationType, StatusCodes.Status201Created, "Tipo de Anotacion Actualizada");

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody]AnnotationTypeDelete request)
        {
            await _annotatitonTypeService.DeleteAnnotationType(request);
            return StatusCode(StatusCodes.Status200OK, "Tipo de Anotacion Eliminada");
        }
    }
}
