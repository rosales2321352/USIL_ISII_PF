using WebApp.Data;
using WebApp.Models;
namespace WebApp.Services
{
    public class OrderService : Service<Order>, IOrderService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IOrderRepository _orderRepository;
        public OrderService(IServiceProvider serviceProvider, IOrderRepository repository, IOrderHistoryRepository historyRepository) : base(repository)
        {
            _orderRepository = repository;
            _serviceProvider = serviceProvider;
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

        public async Task<object> CreateOrder(OrderRequest request)
        {
            IOrderHistoryService orderHistoryService = _serviceProvider.GetRequiredService<IOrderHistoryService>();
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

            await orderHistoryService.CreateNewOrderHistory(order.OrderID);

            var response = new
            {
                order.OrderID,
                order.Name,
                order.CreationDate,
                order.TotalAmount,
                order.OrderStatusID,
                order.ClientID,
                order.SellerID
            };

            return response;
        }

        public async Task<object> UpdateOrderStatus(OrderStatusUpdate request)
        {
            IOrderHistoryService orderHistoryService = _serviceProvider.GetRequiredService<IOrderHistoryService>();
            var order = await _repository.GetById(request.OrderID);
            order.OrderStatusID = request.OrderStatusID;

            await orderHistoryService.CreateOrderHistory(request);

            await _repository.Update(order);
            var response = new
            {
                order.OrderID,
                order.Name,
                order.CreationDate,
                order.TotalAmount,
                order.OrderStatusID,
                order.ClientID,
                order.SellerID
            };

            return response;
        }

        public async Task<object> EditOrder(OrderEdit request)
        {
            IOrderHistoryService orderHistoryService = _serviceProvider.GetRequiredService<IOrderHistoryService>();
            var order = await _repository.GetById(request.OrderID);

            if (order.OrderStatusID != request.OrderStatusID)
            {
                order.OrderStatusID = request.OrderStatusID;
                await orderHistoryService.CreateOrderHistory(request.OrderID, request.OrderStatusID);
            }

            order.ShippingAddress = request.Address;
            order.GeographicLocation = request.Location;
            order.ContactName = request.ContactName;
            order.TotalAmount = request.TotalAmount;

            await _repository.Update(order);

            var response = new
            {
                order.OrderID,
                order.Name,
                order.CreationDate,
                order.TotalAmount,
                order.OrderStatusID,
                order.ClientID,
                order.SellerID,
                order.ShippingAddress,
                order.GeographicLocation,
                order.ContactName,
            };

            return response;
        }

        public async Task DeleteOrder(int id)
        {
            var order = await _repository.GetById(id);
            order.IsAvailable = false;
            await _repository.Update(order);
        }
    }
}