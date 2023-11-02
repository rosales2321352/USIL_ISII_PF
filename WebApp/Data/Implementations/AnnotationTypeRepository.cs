using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class AnnotationTypeRepository : Repository<AnnotationType>, IAnnotationTypeRepository
    {
        public AnnotationTypeRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllAnnotationTypes()
        {
            var list = await _context.AnnotationTypes
            .OrderBy(e=> e.AnnotationTypeID)
            .Select(type => new
            {
                type.AnnotationTypeID,
                type.Name
            }).ToListAsync();

            return list;
        }        
    }
}