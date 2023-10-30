namespace WebApp.Models
{
    public class Client : Person
    {
        public int SellerID { get; set; }
        public Seller Seller { get; set; } = null!;
        public int ClientStatusID { get; set; }
        public virtual ClientStatus ClientStatus { get; set; } = null!;
        public int CompanyID { get; set; }
        public virtual Company Company { get; set; } = null!;
        public ICollection<Event> Events { get; } = new List<Event>();
        public ICollection<Annotation> Annotations { get; } = new List<Annotation>();
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Opportunity> Opportunities { get; } = new List<Opportunity>();
        public ICollection<Conversation> Conversations { get; } = new List<Conversation>();
    }
}

