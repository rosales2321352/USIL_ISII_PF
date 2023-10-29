namespace WebApp.Models
{
    public class EventType
    {
        public int EventTypeID { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsAvailable { get; set; }
        public ICollection<Event> Events { get; set; } = new List<Event>();
    }
}