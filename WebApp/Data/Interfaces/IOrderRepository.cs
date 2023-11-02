using WebApp.Models;
namespace WebApp.Data
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<IEnumerable<object>> GetAllOrders();
        Task<object> GetOrderById(int id);
        Task<IEnumerable<object>> GetOrdersByStatus(int id);
        Task UpdateOrderStatus(Order entity, OrderStatusHistory register, IOrderHistoryRepository orderHistoryRepository);
    }
}
