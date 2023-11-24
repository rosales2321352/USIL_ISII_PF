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

            if (order is null)
            {
                //TODO! Json Error
                return StatusCode(StatusCodes.Status404NotFound, "No existe");
            }
            else
            {
                ApiSingleObjectResponse<object> response = new(order, StatusCodes.Status200OK, "Pedido Encontrado");
                return StatusCode(StatusCodes.Status200OK, response);
            }

        }

        [HttpGet]
        [Route("by-status/{id:int}")]
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
                var order = await _orderService.CreateOrder(request);

                ApiSingleObjectResponse<object> response = new(order, StatusCodes.Status200OK, "Orden Creada");
                return StatusCode(StatusCodes.Status200OK, response);
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
                var order = await _orderService.UpdateOrderStatus(request);
                ApiSingleObjectResponse<object> response = new(order, StatusCodes.Status200OK, "Orden Actualizada");
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
            var order = await _orderService.EditOrder(request);
            ApiSingleObjectResponse<object> response = new(order, StatusCodes.Status200OK, "Orden Actualizada");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] OrderDelete request)
        {
            await _orderService.DeleteOrder(request.OrderID);
            return StatusCode(StatusCodes.Status200OK, "Orden Eliminada");
        }
    }
}
