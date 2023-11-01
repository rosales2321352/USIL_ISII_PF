using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OrderStatusRepository : Repository<OrderStatus>, IOrderStatusRepository
    {
        public OrderStatusRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<IEnumerable<object>> GetAllOrderStatuses()
        {
            var list = await _context.OrderStatuses
            .OrderBy(e => e.OrderStatusID)
            .Select(status => new
            {
                status.OrderStatusID,
                status.Name
            }).ToListAsync();

            return list;
        }
    }
}