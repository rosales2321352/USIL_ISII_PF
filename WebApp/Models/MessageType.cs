namespace WebApp.Models
{
    public class MessageType
    {
        public int MessageTypeId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Message> Messages { get; set; } = new List<Message>();
    }
}