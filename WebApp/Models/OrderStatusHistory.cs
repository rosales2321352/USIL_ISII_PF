namespace WebApp.Models
{
    public class OrderStatusHistory
    {
        public int OrderStatusHistoryID { get; set; }
        public DateOnly UpdateDate { get; set; }
        public string? Comment { get; set; }
        public int OrderID { get; set; }
        public Order Order { get; set; } = null!;
        public int OrderStatusID { get; set; }
        public OrderStatus OrderStatus { get; } = null!;
    }
}