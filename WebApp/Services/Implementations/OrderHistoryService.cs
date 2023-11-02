using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OrderHistoryService : Service<OrderStatusHistory>, IOrderHistoryService
    {
        private readonly IOrderHistoryRepository _orderHistoryRepository;
        public OrderHistoryService(IOrderHistoryRepository repository) : base(repository) 
        { 
            _orderHistoryRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllHistory(int id)
        {
            return await _orderHistoryRepository.GetOrdersHistory(id);
        } 
    }
}