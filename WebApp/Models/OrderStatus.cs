using WebApp.Models;

namespace WebApp.Models
{
    public class OrderStatus
    {
        public int OrderStatusID { get; set; }
        public string Name {get; set;} = null!;
        public ICollection<Order> Orders { get; } = new List<Order>();
    }
}