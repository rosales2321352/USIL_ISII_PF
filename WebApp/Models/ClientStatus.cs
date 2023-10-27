namespace WebApp.Models
{
    public class ClientStatus
    {
        public int ClientStatusID {get; set;}
        public string Name {get; set;} = null!;
        public ICollection<Client> Clients { get; } = new List<Client>();
    }
}