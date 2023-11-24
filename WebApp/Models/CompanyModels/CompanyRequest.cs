namespace WebApp.Models
{
    public class CompanyRequest
    {
        public int? CompanyID { get; set; }
        public string Name { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string RUC { get; set; } = null!;
    }
}