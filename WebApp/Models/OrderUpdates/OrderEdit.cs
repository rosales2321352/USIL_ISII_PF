namespace WebApp.Models
{
    public class OrderEdit
    {
        public int OrderID { get; set; }
        public string? Address { get; set; }
        public string? Location { get; set; }
        public string? ContactName { get; set; }
        public decimal? TotalAmount { get; set; }
        public int OrderStatusID { get; set; }
    }

}
