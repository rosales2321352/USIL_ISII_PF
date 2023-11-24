using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/annotations")]
    [ApiController]
    public class AnnotationController : ControllerBase
    {
        private readonly IAnnotationService _annotationService;

        public AnnotationController(IAnnotationService annotationService)
        {
            _annotationService = annotationService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetAllAnnotations()
        {
            var list = await _annotationService.GetAllAnnotations();
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("by-client/{id:int}")]
        public async Task<IActionResult> GetAnnotationsByClient(int id)
        {
            var list = await _annotationService.GetAnnotationsByClient(id);
            ApiListResponse<object> response = new(list, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetAnnotationDetail(int id)
        {
            var annotation = await _annotationService.GetAnnotationDetail(id);
            ApiSingleObjectResponse<object> response = new(annotation, StatusCodes.Status200OK, "Anotacion Obtenida");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAnnotation([FromBody] AnnotationRequest request)
        {
            var annotation = await _annotationService.CreateAnnotation(request);
            ApiSingleObjectResponse<object> response = new(annotation, StatusCodes.Status201Created, "Anotacion Creada");
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> EditAnnotation([FromBody] AnnotationUpdate request)
        {
            var annotation = await _annotationService.EditAnnotation(request);
            ApiSingleObjectResponse<object> response = new(annotation, StatusCodes.Status200OK, "Anotacion Actualizada");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")] //! Eliminacion fisica
        public async Task<IActionResult> DeleteAnnotation([FromBody] AnnotationDelete request)
        {
            await _annotationService.DeleteAnnotation(request);
            return StatusCode(StatusCodes.Status200OK, "Anotacion Eliminada");
        }
    }
}