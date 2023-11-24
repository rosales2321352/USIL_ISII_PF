namespace WebApp.Models
{
    public class EventRequest
    {
        public int? EventID { get; set; }
        public int ClientID { get; set; }
        public int SellerID { get; set; }
        public string Title { get; set; } = null!;
        public DateOnly DateAssigned { get; set; }
        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public string? Description { get; set; }
        public int EventTypeID { get; set; }
    }
}