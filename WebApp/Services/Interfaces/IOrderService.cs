using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderService : IService<Order>
    {
        Task<IEnumerable<object>> GetAllOrders();
        Task<object?> GetOrderById(int id);
        Task<IEnumerable<object>> GetOrdersByStatus(int id);
        Task<object> CreateOrder(OrderRequest request);
        Task<object> UpdateOrderStatus(OrderStatusUpdate request);
        Task<object> EditOrder(OrderEdit request);
        Task DeleteOrder(int id);
    }
}