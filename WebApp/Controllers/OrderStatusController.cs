using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/orderstatus")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(ApplicationDbContext context, IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
            _context = context;
        }

        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> GetList()
        {
            var orderStatuses = await _orderStatusService.GetAllOrderStatus();
            ApiListResponse<object> apiResponse = new(orderStatuses, StatusCodes.Status200OK);

            return StatusCode(StatusCodes.Status200OK, orderStatuses);
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
