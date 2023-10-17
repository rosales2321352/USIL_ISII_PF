namespace WebApp.Models
{
    public class Seller
    {
        public int SellerID { get; set; }

        public string Name { get; set; } = null!;
        public string Phonenumber { get; set; } = null!;

        public ICollection<Client> Clients { get; } = new List<Client>();
        public ICollection<Event> Events { get; } = new List<Event>();
        public ICollection<Annotation> Annotations { get; } = new List<Annotation>();
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<Opportunity> Opportunities { get; } = new List<Opportunity>();
    }
}