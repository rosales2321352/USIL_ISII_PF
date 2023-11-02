namespace WebApp.Models
{
    public class OrderRequest
    {
        public string Title { get; set; } = null!;
        public decimal? TotalAmount { get; set; }
        public int ClientID { get; set; }
        public int SellerID { get; set; }
    }
}