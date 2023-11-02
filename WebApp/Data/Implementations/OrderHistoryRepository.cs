using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OrderHistoryRepository : Repository<OrderStatusHistory>, IOrderHistoryRepository
    {
        public OrderHistoryRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<object>> GetOrdersHistory(int id)
        {
            var lista = await _context.OrderStatusHistories
            .OrderBy(e => e.UpdateDate)
            .Where(e => e.OrderID == id)
            .Select(track => new
            {
                Date = track.UpdateDate,
                track.Comment,
                Order = new
                {
                    track.Order.Name,
                    track.Order.TotalAmount,
                    track.Order.ContactName
                },
                Client = new
                {
                    track.Order.Client.Name,
                    track.Order.Client.PhoneNumber
                },
                OrderStatus = new
                {
                    track.OrderStatus.OrderStatusID,
                    track.OrderStatus.Name
                }
            }).ToListAsync();
            return lista;
        }
    }
}