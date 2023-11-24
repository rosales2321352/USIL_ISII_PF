using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderHistoryService : IService<OrderStatusHistory>
    {
        Task<IEnumerable<object>> GetAllHistory(int id);
        Task CreateOrderHistory(OrderStatusUpdate request);
        Task CreateOrderHistory(int orderID, int orderStatusID);
        Task CreateNewOrderHistory(int orderID);
    }
}