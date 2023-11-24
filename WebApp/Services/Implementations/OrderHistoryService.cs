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

        public async Task CreateOrderHistory(OrderStatusUpdate request)
        {
            OrderStatusHistory orderHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OrderID = request.OrderID,
                OrderStatusID = request.OrderStatusID,
                Comment = request.Comment
            };
            await _repository.Add(orderHistoryRegister);
        }

        public async Task CreateOrderHistory(int orderID, int orderStatusID)
        {
             OrderStatusHistory orderHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OrderID = orderID,
                OrderStatusID = orderStatusID
            };
            await _repository.Add(orderHistoryRegister);
        }

        public async Task CreateNewOrderHistory(int orderID)
        {
             OrderStatusHistory orderHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OrderID = orderID,
                OrderStatusID = 1,
                Comment = "Pedido Creado"
            };
            await _repository.Add(orderHistoryRegister);
        }
    }
}