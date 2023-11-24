using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<object>> GetAllClients()
        {
            var list = await _context.Clients
            .OrderByDescending(e => e.PersonID)
            .Select(e => new
            {
                ClientId = e.PersonID,
                e.Name,
                e.PhoneNumber,
                e.Email,
                Company = new
                {
                    CompanyID = e.Company != null ? e.Company.CompanyID : (int?)null,
                    e.Company.Address,
                    e.Company.Name,
                    e.Company.RUC,
                    e.Company.Email
                },
                Status = new
                {
                    e.ClientStatus.ClientStatusID,
                    e.ClientStatus.Name
                },
                WhatsappData = new
                {
                    e.WhatsappData.WhatsappID,
                    e.WhatsappData.PhonenumberCode
                },
                SellerID = e.SellerID != null ? e.Seller.PersonID : (int?)null
            }).ToListAsync();

            return list;
        }

        public async Task<IEnumerable<object>> GetClientsWithName()
        {
            var list = await _context.Clients
            .OrderByDescending(e => e.PersonID)
            .Where(e => e.Name != null)
            .Select(e => new
            {
                ClientId = e.PersonID,
                e.Name,
                e.PhoneNumber,
                e.Email,
                Company = new
                {
                    CompanyID = e.Company != null ? e.Company.CompanyID : (int?)null,
                    e.Company.Address,
                    e.Company.Name,
                    e.Company.RUC,
                    e.Company.Email
                },
                Status = new
                {
                    e.ClientStatus.ClientStatusID,
                    e.ClientStatus.Name
                },
                WhatsappData = new
                {
                    e.WhatsappData.WhatsappID,
                    e.WhatsappData.PhonenumberCode
                },
                SellerID = e.SellerID != null ? e.Seller.PersonID : (int?)null,
                TotalOrders = e.Orders.Count(e => e.OrderStatusID != 3),
                TotalOrdersCanceled = e.Orders.Count(e => e.OrderStatusID == 3),
                TotalOrdersFinalize = e.Orders.Count(e => e.OrderStatusID == 4),
                TotalOpportunities = e.Opportunities.Count(e => e.OpportunityID != 3),
                TotalOpportunitiesCanceled = e.Opportunities.Count(e => e.OpportunityID == 3)
            }).ToListAsync();

            return list;
        }
        public async Task<Client?> GetClientByWhatsappId(string id)
        {
            Client? client = await _context.Clients.FirstOrDefaultAsync(e => e.WhatsappID.Equals(id));
            return client;
        }
        public async Task<object?> GetClientDetail(int id)
        {
            var client = await _context.Clients
            .Select(e => new
            {
                ClientId = e.PersonID,
                e.Name,
                e.PhoneNumber,
                e.Email,
                Company = new
                {
                    CompanyID = e.Company != null ? e.Company.CompanyID : (int?)null,
                    e.Company.Address,
                    e.Company.Name,
                    e.Company.RUC,
                    e.Company.Email
                },
                Status = new
                {
                    e.ClientStatus.ClientStatusID,
                    e.ClientStatus.Name
                },
                WhatsappData = new
                {
                    e.WhatsappData.WhatsappID,
                    e.WhatsappData.PhonenumberCode
                },
                SellerID = e.SellerID != null ? e.Seller.PersonID : (int?)null,
                TotalOrders = e.Orders.Count(e => e.OrderStatusID != 3),
                TotalOrdersCanceled = e.Orders.Count(e => e.OrderStatusID == 3),
                TotalOrdersFinalize = e.Orders.Count(e => e.OrderStatusID == 4),
                TotalOpportunities = e.Opportunities.Count(e => e.OpportunityID != 3),
                TotalOpportunitiesCanceled = e.Opportunities.Count(e => e.OpportunityID == 3)
            }).FirstOrDefaultAsync(e => e.ClientId == id);

            if(client is null)
                return null;
            else
                return client;
        }
    }
}