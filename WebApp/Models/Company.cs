namespace WebApp.Models
{
    public class Company
    {
        public int CompanyID { get; set; }
        public string Name { get; set; } = null!;
        public string RUC { get; set; } = null!;
        public string? Address { get; set; }
        public string? Email { get; set; }
        public ICollection<Client> Clients { get; } = new List<Client>();
    }
}
