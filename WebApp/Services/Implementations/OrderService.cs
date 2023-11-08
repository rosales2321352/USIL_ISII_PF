using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository; //!PREGUNTAR
        private readonly IOrderHistoryRepository _orderHistoryRepository; //!PREGUNTAR
        public OrderService(IOrderRepository repository, IOrderHistoryRepository historyRepository) : base(repository)
        {
            _orderRepository = repository;
            _orderHistoryRepository = historyRepository;
        }

        public async Task<IEnumerable<object>> GetAllOrders()
        {

            return await _orderRepository.GetAllOrders();
        }

        public async Task<object?> GetOrderById(int id)
        {
            return await _orderRepository.GetOrderById(id);
        }

        public async Task<IEnumerable<object>> GetOrdersByStatus(int id)
        {
            return await _orderRepository.GetOrdersByStatus(id);
        }

        public async Task CreateOrder(OrderRequest request)
        {
            Order order = new()
            {
                Name = request.Title,
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                TotalAmount = request.TotalAmount,
                OrderStatusID = 1,
                ClientID = request.ClientID,
                SellerID = request.SellerID
            };

            await _repository.Add(order);

            OrderStatusHistory orderHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OrderID = order.OrderID,
                OrderStatusID = 1,
                Comment = "Pedido Creado"
            };

            await _orderHistoryRepository.Add(orderHistoryRegister);
        }

        public async Task UpdateOrderStatus(OrderStatusUpdate request)
        {
            var order = await _repository.GetById(request.OrderID);
            order.OrderStatusID = request.OrderStatusID;

            OrderStatusHistory orderHistoryRegister = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                OrderID = request.OrderID,
                OrderStatusID = request.OrderStatusID,
                Comment = request.Comment
            };
            //TODO _orderHistoryService.Add(orderHistoryRegister);
            //TODO _orderRepository.UpdateOrderStatus(order);

            await _orderRepository.UpdateOrderStatus(order, orderHistoryRegister, _orderHistoryRepository);
        }

        public async Task EditOrder(OrderEdit request)
        {
            var order = await _repository.GetById(request.OrderID);

            if (order.OrderStatusID != request.OrderStatusID)
            {
                order.OrderStatusID = request.OrderStatusID;
                OrderStatusHistory orderHistoryRegister = new()
                {
                    UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                    OrderID = request.OrderID,
                    OrderStatusID = request.OrderStatusID
                };
                await _orderHistoryRepository.Add(orderHistoryRegister);

            }

            order.ShippingAddress = request.Address;
            order.GeographicLocation = request.Location;
            order.ContactName = request.ContactName;
            order.TotalAmount = request.TotalAmount;

            await _repository.Update(order);

        }
    }
}