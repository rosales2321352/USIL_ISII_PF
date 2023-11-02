using WebApp.Models;
namespace WebApp.Services
{
    public interface IOrderHistoryService : IService<OrderStatusHistory>
    {
        Task<IEnumerable<object>> GetAllHistory(int id);
    }
}