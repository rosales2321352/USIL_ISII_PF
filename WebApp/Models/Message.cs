namespace WebApp.Models
{
    public class Message
    {
        public string MessageID { get; set; } = null!;
        public int ConversationID { get; set; }
        public Conversation Conversation { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string WhatsappID { get; set; } = null!;
        public int MessageTypeId { get; set; }
        public MessageType MessageType { get; set; } = null!;
    }
}