using WebApp.Models;
namespace WebApp.Data
{
    public class AnnotationRepository : Repository<Annotation>, IAnnotationRepository
    {
        public AnnotationRepository(ApplicationDbContext context) : base(context) { }
    }
}