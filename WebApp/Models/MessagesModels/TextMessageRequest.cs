namespace WebApp.Models
{
    public class TextMessageRequest
    {
        public int ConversationID { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public string Text { get; set; } = null!;
    }
}