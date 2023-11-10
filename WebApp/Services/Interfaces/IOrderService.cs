using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<IEnumerable<object>> GetAllOrders();
        Task<object?> GetOrderById(int id);
        Task<IEnumerable<object>> GetOrdersByStatus(int id);
        Task CreateOrder(OrderRequest request);
        Task UpdateOrderStatus(OrderStatusUpdate request);
        Task EditOrder(OrderEdit request);
    }
}