using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OrderStatusService : Service<OrderStatus>, IOrderStatusService
    {
        private readonly IOrderStatusRepository _orderStatusRepository;
        public OrderStatusService(IOrderStatusRepository repository) : base(repository) 
        { 
            _orderStatusRepository = repository;
        }

        public async Task<IEnumerable<object>> GetAllOrderStatus()
        {
            return await _orderStatusRepository.GetAllOrderStatuses();
        }
        public async Task<object> CreateOrderStatus(OrderStatusRequest request)
        {
            OrderStatus orderStatus = new ()
            {
                Name = request.Name
            };

            await _repository.Add(orderStatus);
            request.StatusID = orderStatus.OrderStatusID;
            return request;
        }
        public async Task<object> EditOrderStatus(OrderStatusRequest request)
        {
            int statusId = request.StatusID ?? 0;
            var orderStatus = await _repository.GetById(statusId);

            orderStatus.Name = request.Name;

            await _repository.Update(orderStatus);
            return request;
        }

        public async Task DeleteOrderStatus(int id)
        {
            var orderStatus = await _repository.GetById(id);
            orderStatus.IsAvailable = false;
            await _repository.Update(orderStatus);
        }
    }
}