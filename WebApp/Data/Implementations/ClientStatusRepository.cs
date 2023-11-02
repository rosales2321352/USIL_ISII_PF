using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class ClientStatusRepository : Repository<ClientStatus>, IClientStatusRepository
    {
        public ClientStatusRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}