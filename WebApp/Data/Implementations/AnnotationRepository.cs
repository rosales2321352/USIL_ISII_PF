using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class AnnotationRepository : Repository<Annotation>, IAnnotationRepository
    {
        public AnnotationRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllAnnotations()
        {
            var list = await _context.Annotations
            .OrderByDescending(e => e.AnnotationID)
            .Select(annotation => new 
            {
                annotation.AnnotationID,
                annotation.Title,
                annotation.Description,
                Client = new 
                {
                    annotation.Client.Name,
                    annotation.Client.PhoneNumber
                },
                Type = new
                {
                    annotation.AnnotationType.Name
                }
            }).ToListAsync();

            return list;
        }

        public async Task<object> GetAnnotationDetail(int id)
        {   
            var annotation = await _context.Annotations
            .Select(annotation => new 
            {
                annotation.AnnotationID,
                annotation.Title,
                annotation.Description,
                Client = new 
                {
                    annotation.Client.Name,
                    annotation.Client.PhoneNumber
                },
                Type = new
                {
                    annotation.AnnotationType.Name
                }
            }).FirstOrDefaultAsync(e => e.AnnotationID == id);

            if (annotation is null)
                return default!; 
            else
            //TODO! 
                return annotation;
        }

        public async Task<IEnumerable<object>> GetAnnotationsByClient(int id)
        {
            var list = await _context.Annotations
            .OrderByDescending(e => e.AnnotationID)
            .Where(e => e.ClientID == id)
            .Select(annotation => new 
            {
                annotation.AnnotationID,
                annotation.Title,
                annotation.Description,
                Client = new 
                {
                    annotation.Client.Name,
                    annotation.Client.PhoneNumber
                },
                Type = new
                {
                    annotation.AnnotationType.Name
                }
            }).ToListAsync();

            return list;
        }
    }
}