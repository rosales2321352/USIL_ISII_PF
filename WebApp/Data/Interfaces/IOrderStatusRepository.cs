using WebApp.Models;
namespace WebApp.Data
{
    public interface IOrderStatusRepository : IRepository<OrderStatus>
    {
        Task<IEnumerable<object>> GetAllOrderStatuses();
    }
}