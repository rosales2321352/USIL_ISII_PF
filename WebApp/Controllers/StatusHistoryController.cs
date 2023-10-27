using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class StatusHistoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatusHistoryController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("HistorialPedidos/{id:int}")]
        public async Task<IActionResult> GetOrdersHistory(int id)
        {
            var lista = await _context.OrderStatusHistories
            .Include(e => e.Order)
            .Include(e => e.OrderStatus)
            .Where(e => e.OrderID == id)
            .AsNoTracking()
            .Select(e=> new
            {
                e.UpdateDate,
                e.Comment,
                ClientName = e.Order.Client.Name,
                StatusName = e.OrderStatus.Name
            })
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("HistorialOportunidades/{id:int}")]
        public async Task<IActionResult> GetOpportunitiesHistory(int id)
        {
            var lista = await _context.OpportunityStatusHistories
            .Include(e => e.Opportunity)
            .Include(e => e.OpportunityStatus)
            .Where(e => e.OpportunityID == id)
            .AsNoTracking()
            .Select(e=> new
            {
                e.UpdateDate,
                e.Comment,
                ClientName = e.Opportunity.Client.Name,
                StatusName = e.OpportunityStatus.Name
            })
            .ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

    }
}
