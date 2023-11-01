using Microsoft.AspNetCore.Mvc;
using WebApp.Data;
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
            ApiSingleObjectResponse<Annotation> response = new(annotation, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateAnnotation([FromBody] AnnotationRequest request)
        {
            await _annotationService.CreateAnnotation(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] AnnotationUpdate request)
        {
            await _annotationService.EditAnnotation(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("delete")] //! Eliminacion fisica
        public async Task<IActionResult> Delete([FromBody] AnnotationDelete request)
        {
            await _annotationService.DeleteAnnotation(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
    }
}