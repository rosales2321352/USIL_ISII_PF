namespace WebApp.Models
{
    public class OrderStatusRequest
    {
        public int? StatusID { get; set; }
        public string Name { get; set; } = null!;
    }
}