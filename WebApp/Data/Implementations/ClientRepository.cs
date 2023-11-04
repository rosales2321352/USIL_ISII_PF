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
                    e.Company.Address,
                    e.Company.Name
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
                }
            }).ToListAsync();

            return list;
        }
        public async Task<Client> GetClient(string id)
        {
            Client? client = await _context.Clients.FindAsync(id);
            if (client is null)
            {
                return default!;
            }
            else
            {
                return client;
            }
        }
    }
}