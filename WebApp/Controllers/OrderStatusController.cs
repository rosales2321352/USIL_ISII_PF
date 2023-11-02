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
            await _orderStatusService.CreateOrderStatus(request);
            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpPut]
        [Route("edit")]
        public async Task<IActionResult> Edit([FromBody] OrderStatusRequest request)
        {
            await _orderStatusService.EditOrderStatus(request);

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        //TODO Eliminacion logica y fisica de estados.
        
    }
}
