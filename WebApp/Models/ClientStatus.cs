namespace WebApp.Models
{
    public class ClientStatus
    {
        public int ClientStatusID {get; set;}
        public string Name {get; set;} = null!;
        public bool? IsAvailable { get; set; }
        public ICollection<Client> Clients { get; } = new List<Client>();
    }
}