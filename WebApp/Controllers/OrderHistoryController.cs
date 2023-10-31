using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Helpers;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/orderstatushistory")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistoryService _orderHistoryService;
        public OrderHistoryController(IOrderHistoryService orderHistoryService)
        {
            _orderHistoryService = orderHistoryService;
        }

        [HttpGet]
        [Route("all/{id:int}")]
        public async Task<IActionResult> GetOrdersHistory(int id)
        {
            var lista = await _orderHistoryService.GetAllHistory(id);

            ApiListResponse<object> apiResponse = new(lista, StatusCodes.Status200OK);
            return StatusCode(StatusCodes.Status200OK, apiResponse);
        }

    }
}
