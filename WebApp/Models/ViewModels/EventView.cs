namespace WebApp;

public class EventView
{
    public string Title { get; set; } = null!;
    public int EventTypeID { get; set; }
    public DateOnly DateAssigned { get; set; }
    public string? Description { get; set; }
    public int ClientID { get; set; }

}