using WebApp.Models;
namespace WebApp.Data
{
    public class WhatsappDataRepository : Repository<WhatsappData>, IWhatsappDataRepository
    {
        public WhatsappDataRepository(ApplicationDbContext context) : base(context)
        {
            
        }
    }
}