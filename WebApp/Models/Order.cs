namespace WebApp.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public string Name { get; set; } = null!;
        public DateOnly CreationDate { get; set; }
        public string? ShippingAddress { get; set; }
        public string? GeographicLocation { get; set; }
        public string? ContactName { get; set; }
        public decimal? TotalAmount { get; set; }
        public bool? IsAvailable { get; set; }
        public int OrderStatusID { get; set; }
        public virtual OrderStatus OrderStatus { get; set; } = null!;
        public int ClientID { get; set; }
        public virtual Client Client { get; set; } = null!;
        public int SellerID { get; set; }
        public virtual Seller Seller { get; set; } = null!;
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}