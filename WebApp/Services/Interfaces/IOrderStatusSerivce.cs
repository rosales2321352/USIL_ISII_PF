using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderStatusService : IService<OrderStatus>
    {
        Task<IEnumerable<object>> GetAllOrderStatus();
        Task<object> CreateOrderStatus(OrderStatusRequest request);
        Task<object> EditOrderStatus(OrderStatusRequest request);
        Task DeleteOrderStatus(int id);
    }
}