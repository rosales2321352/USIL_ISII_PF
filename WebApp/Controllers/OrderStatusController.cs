using Microsoft.AspNetCore.Mvc;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Route("api/order-status")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetOrderStatuses()
        {
            var orderStatuses = await _orderStatusService.GetAllOrderStatus();
            ApiListResponse<object> apiResponse = new(orderStatuses, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, apiResponse);
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrderStatus([FromBody] OrderStatusRequest request)
        {
            var orderStatus = await _orderStatusService.CreateOrderStatus(request);
            ApiSingleObjectResponse<object> response = new(orderStatus, StatusCodes.Status200OK, "Estado de Orden Creada");
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] OrderStatusRequest request)
        {
            var orderStatus = await _orderStatusService.EditOrderStatus(request);
            
            ApiSingleObjectResponse<object> response = new(orderStatus, StatusCodes.Status200OK, "Estado de Orden Actualizada");

            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpDelete]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromBody] OrderStatusDelete request)
        {
            await _orderStatusService.DeleteOrderStatus(request.OrderID);
            return StatusCode(StatusCodes.Status200OK, "Estado de Orden Eliminada");
        }
        
    }
}
