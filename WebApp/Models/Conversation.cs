namespace WebApp.Models
{
    public class Conversation
    {
        public int ConversationID { get; set; }
        public DateOnly StartDate { get; set; }
        public int SellerID { get; set; }
        public Seller Seller { get; set; } = null!;
        public int ClientID { get; set; }
        public Client Client { get; set; } = null!;
        public ICollection<Message> Messages {get; set;} = new List<Message>();
    }
}