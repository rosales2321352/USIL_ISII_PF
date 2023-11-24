using WebApp.Models;
namespace WebApp.Services
{
    public interface IAnnotationService : IService<Annotation>
    {
        Task<IEnumerable<object>> GetAllAnnotations();
        Task<object> GetAnnotationDetail(int id);
        Task<IEnumerable<object>> GetAnnotationsByClient(int id);
        Task<object> CreateAnnotation(AnnotationRequest request);
        Task<object> EditAnnotation(AnnotationUpdate request);
        Task DeleteAnnotation(AnnotationDelete request);
    }
}