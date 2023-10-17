namespace WebApp.Models
{
    public class Event
    {
        public int EventID { get; set; }
        public string Title { get; set; } = null!;
        //TODO Normalizar esta tabla
        public string Type { get; set; } = null!;
        public DateOnly DateAssigned { get; set; }
        public string? Description { get; set; }
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public int ClientID { get; set; }
        public virtual Client Client { get; set; } = null!;
    }
}