namespace WebApp.Models
{
    public class WhatsAppResponse
    {
        public string? MessagingProduct { get; set; } = null!;
        public ContactResponse[] Contacts { get; set; } = null!;
        public MessageResponse[] Messages { get; set; } = null!;
    }
    public class ContactResponse
    {
        public string Input { get; set; } = null!;
        public string Wa_id { get; set; } = null!;
    }

    public class MessageResponse
    {
        public string Id { get; set; } = null!;
    }
}
