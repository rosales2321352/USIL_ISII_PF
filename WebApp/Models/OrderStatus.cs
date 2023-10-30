using WebApp.Models;

namespace WebApp.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string Name { get; set; } = null!;
        public bool? IsAvailable { get; set; }
        public ICollection<Order> Orders { get; } = new List<Order>();
        public ICollection<OrderStatusHistory> OrderStatusHistories { get; set; } = new List<OrderStatusHistory>();
    }
}