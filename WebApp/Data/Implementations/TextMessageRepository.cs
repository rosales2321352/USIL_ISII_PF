using Microsoft.EntityFrameworkCore;
using WebApp.Models;
namespace WebApp.Data
{
    public class TextMessageRepository : Repository<TextMessage>, ITextMessageRepository
    {
        public TextMessageRepository(ApplicationDbContext context) : base(context)
        {

        }
        public async Task<IEnumerable<object>> GetAllTextMessagesFromConversation(int id)
        {
            var list = await _context.TextMessages
            .OrderBy(e => e.Timestamp)
            .Select(msg => new
            {
                msg.Text,
                msg.ConversationID,
                msg.Timestamp,
                Type = new 
                {
                    msg.MessageType.Name
                },
                Person = new
                {
                    msg.WhatsappID
                }
            }).ToListAsync();
            return list;
        }
    }
}