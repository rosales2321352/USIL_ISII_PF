namespace WebApp.Models
{
    public class OrderStatusUpdate
    {
        public int OrderID { get; set; }
        public int OrderStatusID { get; set; }
        public string? Comment { get; set; }
    }
}