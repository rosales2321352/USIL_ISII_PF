using WebApp.Models;
namespace WebApp.Data
{
    public interface IOrderHistoryRepository : IRepository<OrderStatusHistory>
    {
        Task<IEnumerable<object>> GetOrdersHistory(int id);
    }
}
