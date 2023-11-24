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
            return await _context.Conversations.FirstOrDefaultAsync(e => e.ClientID == id && e.SellerID == 1); ;
        }

        public async Task<IEnumerable<object>> GetCompleteConversation(int id)
        {
            var list = await _context.Conversations
            .Where(c => c.ClientID == id && c.SellerID == 1)
            .SelectMany(c => c.Messages.OfType<TextMessage>())
            .ToListAsync();

            return list;
        }
        
    }
}