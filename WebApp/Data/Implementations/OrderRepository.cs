using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task<IEnumerable<object>> GetAllOrders()
        {
            var lista = await _context.Orders
            .OrderByDescending(e => e.OrderID)
            .Select(order => new
            {
                order.OrderID,
                Title = order.Name,
                order.CreationDate,
                order.TotalAmount,
                Client = new
                {
                    order.Client.Name // Aquí obtienes solo el nombre del cliente
                },
                Status = new
                {
                    order.OrderStatus.Name,
                    order.OrderStatusID
                }
            }).ToListAsync();

            return lista;
        }

        public async Task<object?> GetOrderById(int id)
        {
            var order = await _context.Orders
            .Select(e => new
            {
                e.OrderID,
                e.CreationDate,
                Status = new
                {
                    e.OrderStatus.Name,
                    e.OrderStatusID,
                },
                Address = e.ShippingAddress,
                Location = e.GeographicLocation,
                e.ContactName,
                Client = new
                {
                    e.Client.Name,
                    e.Client.PhoneNumber,
                }
            })
            .FirstOrDefaultAsync(e => e.OrderID == id);
            if (order != null)
                return order;
            else
                return null;    //TODO! Que se retorna?
        }

        public async Task<IEnumerable<object>> GetOrdersByStatus(int id)
        {
            var lista = await _context.Orders
            .OrderByDescending(e => e.OrderID)
            .Where(e => e.OrderStatusID == id)
            .Select(order => new
            {
                order.OrderID,
                Title = order.Name,
                order.CreationDate,
                order.TotalAmount,
                Client = new
                {
                    order.Client.Name // Aquí obtienes solo el nombre del cliente
                },
                Status = new
                {
                    order.OrderStatus.Name,
                    order.OrderStatusID
                }
            }).ToListAsync();

            return lista;
        }

        public async Task UpdateOrderStatus(Order entity, OrderStatusHistory register, IOrderHistoryRepository orderHistoryRepository = default!)
        {
            await orderHistoryRepository.Add(register);
            await Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}