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

        public async Task CreateOrderStatus(OrderStatusRequest request)
        {
            OrderStatus orderStatus = new ()
            {
                Name = request.Name
            };

            await _repository.Add(orderStatus);
        }

        public async Task EditOrderStatus(OrderStatusRequest request)
        {
            int statusId = request.StatusID ?? 0;
            var orderStatus = await _repository.GetById(statusId);

            orderStatus.Name = request.Name;

            await _repository.Update(orderStatus);
        }
    }
}