using WebApp.Models;
namespace WebApp.Services
{
    public interface IAnnotationTypeService : IService<AnnotationType>
    {
        Task<IEnumerable<object>> GetAllAnnotationTypes();
        Task CreateAnnotationType(AnnotationTypeRequest request);
        Task EditAnnotationType(AnnotationTypeRequest request);
    }
}