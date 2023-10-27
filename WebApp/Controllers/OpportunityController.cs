using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class OpportunityController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public OpportunityController(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<OpportunityView>> GetAllOpportunities()
        {
            var lista = _context.Opportunities
            .Include(e => e.Client)
            .Include(e => e.Seller)
            .Include(e => e.OpportunityStatus)
            .AsNoTracking()
            .Select(e => new OpportunityView
            {
                OpportunityID = e.OpportunityID,
                CreationDate = e.CreationDate,
                ClientName = e.Client.Name,
                StatusName = e.OpportunityStatus.Name,
                OpportunityStatusID = e.OpportunityStatusID
            }).ToListAsync();

            return lista;
        }

        public async Task<IActionResult> RegisterOpportunityStatusChange(OpportunityStatusUpdate request)
        {
            OpportunityStatusHistory opportunity = new()
            {
                UpdateDate = DateOnly.FromDateTime(DateTime.Now),
                Comment = request.Comment,
                OpportunityID = request.OpportunityID,
                OpportunityStatusID = request.NewStatusID
            };

            await _context.OpportunityStatusHistories.AddAsync(opportunity);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");
        }

        [HttpGet]
        [Route("Lista")]
        public async Task<IActionResult> GetList()
        {
            var lista = await GetAllOpportunities();

            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpGet]
        [Route("ListaEstado/{id:int}")]
        public async Task<IActionResult> GetListByStatus(int id)
        {
            var lista = await GetAllOpportunities();

            var newLista = lista.Where(e => e.OpportunityStatusID == id);

            return StatusCode(StatusCodes.Status200OK, newLista);
        }

        [HttpGet]
        [Route("Detalle/{id:int}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var opportunityDetail = await _context.Opportunities
            .Include(e => e.Client)
            .AsNoTracking().Select(e => new
            {
                e.OpportunityID,
                e.CreationDate,
                ClientName = e.Client.Name,
                ClientPhone = e.Client.PhoneNumber,
                OrderName = e.OpportunityStatus.Name,
                e.OpportunityStatusID
            })
            .FirstOrDefaultAsync(e => e.OpportunityID == id);

            return StatusCode(StatusCodes.Status200OK, opportunityDetail);

        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<IActionResult> SaveCompany([FromBody] int clientId)
        {

            Opportunity opportunity = new()
            {
                CreationDate = DateOnly.FromDateTime(DateTime.Now),
                OpportunityStatusID = 1,
                ClientID = clientId,
                SellerID = 1
            };

            await _context.Opportunities.AddAsync(opportunity);
            await _context.SaveChangesAsync();

            return StatusCode(StatusCodes.Status200OK, "ok");

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<IActionResult> Edit([FromBody] OpportunityStatusUpdate request)
        {
            var opportunityDetail = await _context.Opportunities
            .FirstOrDefaultAsync(e => e.OpportunityID == request.OpportunityID);

            if (opportunityDetail != null)
            {
                if (opportunityDetail.OpportunityStatusID != request.NewStatusID)
                {
                    OpportunityStatusUpdate newStatus = new()
                    {
                        Comment = request.Comment,
                        OpportunityID = request.OpportunityID,
                        NewStatusID = request.NewStatusID
                    };
                    await RegisterOpportunityStatusChange(newStatus);
                }

                opportunityDetail.OpportunityStatusID = request.NewStatusID;
                _context.Opportunities.Update(opportunityDetail);
                await _context.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK, "ok");
            }else
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Not Opportunity Found with that ID");
            }
        }

        [HttpPut]
        [Route("ActualizarEstado")]
        public async Task<IActionResult> UpdateStatus([FromBody] OpportunityStatusUpdate request)
        {
            var opportunityDetail = await _context.Opportunities.FirstOrDefaultAsync(e => e.OpportunityID == request.OpportunityID);
            if(opportunityDetail != null)
            {
                await RegisterOpportunityStatusChange(request);
                
                opportunityDetail.OpportunityStatusID = request.NewStatusID;
                _context.Opportunities.Update(opportunityDetail);
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
