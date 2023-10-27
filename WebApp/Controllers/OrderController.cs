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

        public Task<List<OrderView>> GetAllOrders()
        {
            var lista = _context.Orders
            .Include(e => e.Client)
            .Include(e => e.Seller)
            .Include(e => e.OrderStatus)
            .AsNoTracking()
            .Select(e => new OrderView
            {
                OrderID = e.OrderID,
                CreationDate = e.CreationDate,
                ClientName = e.Client.Name,
                OrderStatus = e.OrderStatus.Name,
                OrderStatusID = e.OrderStatusID
            }).ToListAsync();

            return lista;
        }

        public async Task<IActionResult> RegisterOrderStatusChange(OrderStatusUpdate request)
        {
            OrderStatusHistory order = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                Comment = request.Comment,
                OrderID = request.OrderID,
                OrderStatusID = request.NewStatusID
            };

            await _context.OrderStatusHistories.AddAsync(order);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await GetAllOrders();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("ListaEstado/{id:int}")]
        public async Task<IActionResult> GetListByStatus(int id)
        {
            var lista = await GetAllOrders();

            var newLista = lista.Where(e => e.OrderStatusID == id);

            return StatusCode(StatusCodes.Status200OK, newLista);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var orderDetail = await _context.Orders
            .Include(e => e.Client)
            .AsNoTracking().Select(e => new
            {
                e.OrderID,
                e.CreationDate,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.PhoneNumber,
                OrderName = e.OrderStatus.Name,
                e.OrderStatusID,
                Address = e.ShippingAddress,
                Location = e.GeographicLocation,
                e.ContactName
            })
            .FirstOrDefaultAsync(e => e.OrderID == id);

            return StatusCode(StatusCodes.Status200OK, orderDetail);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] int clientId)
        {

            Order order = new()
            {
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                AcceptionDate = DateOnly.FromDateTime(DateTime.Now),
                OrderStatusID = 1,
                ClientID = clientId,
                SellerID = 1
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] OrderUpdate request)
        {
            var orderDetail = await _context.Orders
            .FirstOrDefaultAsync(e => e.OrderID == request.OrderID);

            if (orderDetail != null)
            {
                if (orderDetail.OrderStatusID != request.OrderStatusID)
                {
                    OrderStatusUpdate newStatus = new()
                    {
                        OrderID = request.OrderID,
                        NewStatusID = request.OrderStatusID
                    };
                    await RegisterOrderStatusChange(newStatus);
                }

                orderDetail.OrderID = request.OrderID;
                orderDetail.ShippingAddress = request.Address;
                orderDetail.GeographicLocation = request.Location;
                orderDetail.ContactName = request.ContactName;
                orderDetail.OrderStatusID = request.OrderStatusID;

                _context.Orders.Update(orderDetail);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
            }
        }

        [HttpPut]
        [Route("ActualizarEstado")]
        public async Task<IActionResult> UpdateStatus([FromBody] OrderStatusUpdate request)
        {
            var orderDetail = await _context.Orders.FirstOrDefaultAsync(e => e.OrderID == request.OrderID);
            if(orderDetail != null)
            {
                await RegisterOrderStatusChange(request);
                
                orderDetail.OrderStatusID = request.NewStatusID;
                _context.Orders.Update(orderDetail);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Not Order Found with that ID");
            }


        }

        //TODO Confirmar si se puede eliminar un pedido o no
        /*[HttpDelete]
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
        }*/
    }
}
