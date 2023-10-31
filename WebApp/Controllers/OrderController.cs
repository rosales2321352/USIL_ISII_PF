using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                var orders = await _orderService.GetAllOrders();

                ApiListResponse<object> apiResponse = new(orders, StatusCodes.Status200OK);

                return StatusCode(StatusCodes.Status200OK, apiResponse);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
            }
        }
        [HttpGet]
        [Route("detail/{id:int}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);

            ApiSingleObjectResponse<object> response = new(order, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpGet]
        [Route("bystatus/{id:int}")]
        public async Task<IActionResult> GetOrdersByStatus(int id)
        {
            var orders = await _orderService.GetOrdersByStatus(id);

            ApiListResponse<object> response = new(orders, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            try
            {
                await _orderService.CreateOrder(request);
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> UpdateOrderStatus([FromBody] OrderStatusUpdate request)
        {
            try
            {
                await _orderService.UpdateOrderStatus(request);
                return StatusCode(StatusCodes.Status200OK, "ok");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error interno del servidor: " + ex.Message);
            }
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] OrderEdit request)
        {
            await _orderService.EditOrder(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }
        
        //TODO Eliminacion Lógica y Física
    }
}
