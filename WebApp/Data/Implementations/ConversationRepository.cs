using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class ConversationRepository : Repository<Conversation>, IConversationRepository
    {
        public ConversationRepository(ApplicationDbContext context) : base(context)
        {

        }

        public async Task<Conversation?> GetByClientId(int id)
        {
            return await _context.Conversations.FirstOrDefaultAsync(e => e.ClientID == id && e.SellerID == 1);;
        }
    }
}