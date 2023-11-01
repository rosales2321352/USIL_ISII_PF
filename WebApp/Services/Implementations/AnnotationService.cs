using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class AnnotationService : Service<Annotation>, IAnnotationService
    {
        public AnnotationService(IAnnotationRepository repository) : base(repository) { }
    }
}