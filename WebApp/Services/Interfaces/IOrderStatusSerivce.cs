using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderStatusService : IService<OrderStatus>
    {
        Task<IEnumerable<object>> GetAllOrderStatus();
        Task CreateOrderStatus(OrderStatusRequest request);
        Task EditOrderStatus(OrderStatusRequest request);
    }
}