namespace WebApp.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public string Name { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string WhatsappID {get; set;}= null!;
        public virtual WhatsappData WhatsappData {get; set;} = null!;
        public string Email { get; set; } = null!;

    }
}