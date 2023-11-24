using WebApp.Models;
namespace WebApp.Services
{
    public interface IAnnotationTypeService : IService<AnnotationType>
    {
        Task<IEnumerable<object>> GetAllAnnotationTypes();
        Task<object> CreateAnnotationType(AnnotationTypeRequest request);
        Task<object> EditAnnotationType(AnnotationTypeRequest request);
        Task DeleteAnnotationType(AnnotationTypeDelete request);
    }
}