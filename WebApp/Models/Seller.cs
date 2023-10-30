namespace WebApp.Models
{
    public class Seller : Person
    {
        public string Username {get; set;} = null!;
        public string Password {get; set;} = null!;
        public ICollection<Client> Clients { get; } = new List<Client>();
        public ICollection<Event> Events { get; } = new List<Event>();
        public ICollection<Annotation> Annotations { get; } = new List<Annotation>();
        public ICollection<Conversation> Conversations { get; } = new List<Conversation>();
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Opportunity> Opportunities { get; } = new List<Opportunity>();
    }
}