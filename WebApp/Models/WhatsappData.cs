using System.ComponentModel.DataAnnotations;
using WebApp.Models;

namespace WebApp.Data
{
    public class WhatsappData
    {
        [Key]
        public string WhatsappID { get; set; } = null!;
        public DateTime FirstMessageDate { get; set; }
        public string PhonenumberCode { get; set; } = null!;
        public string WhatsappName { get; set; } = null!;
        public ICollection<Message> Messages { get; set; } = new List<Message>();
        public Client Client { get; set; } = null!;
    }
}