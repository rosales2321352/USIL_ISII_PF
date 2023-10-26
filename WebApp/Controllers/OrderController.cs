using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OrderController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await _context.Orders.Include(e => e.Client).Include(e => e.Seller).Include(e => e.OrderStatus).AsNoTracking().Select(e => new OrderView
            {
                OrderID = e.OrderID,
                CreationDate = e.CreationDate,
                ClientName = e.Client.Name,
                OrderStatus = e.OrderStatus.Name
            }).ToListAsync();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            Order? orderDetail = await _context.Orders.Include(e => e.Client).AsNoTracking().FirstOrDefaultAsync(e => e.OrderID == id);

            if (orderDetail != null)
            {
                OrderDetail orderDetails = new()
                {
                    OrderID = orderDetail.OrderID,
                    OrderStatus = orderDetail.OrderStatus.Name,
                    ClientName = orderDetail.Client.Name,
                    ClientPhone = orderDetail.Client.PhoneNumber,
                    Address = orderDetail.ShippingAddress,
                    Location = orderDetail.GeographicLocation
                };

                return StatusCode(StatusCodes.Status200OK, orderDetail);
            }

            return StatusCode(StatusCodes.Status404NotFound, "No Order with that ID");
            
        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] Order request)
        {

            await _context.Orders.AddAsync(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] Order request)
        {
            _context.Orders.Update(request);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpDelete]
        [Route("Eliminar/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            Order? order = await _context.Orders.FindAsync(id);

            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK, "ok");

            }

            return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
        }
    }
}
