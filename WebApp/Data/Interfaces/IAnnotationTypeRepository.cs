using WebApp.Models;
namespace WebApp.Data
{
    public interface IAnnotationTypeRepository : IRepository<AnnotationType>
    {
        Task<IEnumerable<object>> GetAllAnnotationTypes();
    }
}