namespace WebApp.Models
{
    public class EventUpdate
    {
        public int EventID { get; set; }
        public string Title { get; set; } = null!;
        public int EventTypeID { get; set; }
        public DateOnly DateAssigned { get; set; }
        public TimeSpan BeginTime {get; set;}
        public TimeSpan EndTime {get; set;}
        public string? Description { get; set; }
    }
}
