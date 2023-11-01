using WebApp.Models;
namespace WebApp.Data
{
    public interface IAnnotationRepository : IRepository<Annotation>
    {
        Task<IEnumerable<object>> GetAllAnnotations();
        Task<IEnumerable<object>> GetAnnotationsByClient(int id);
        Task<object> GetAnnotationDetail(int id);

    } 
}