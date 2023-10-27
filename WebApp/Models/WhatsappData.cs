using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class WhatsappData
    {
        [Key]
        public string WhatsappID { get; set; } = null!;
        public string PhonenumberCode { get; set; } = null!;
        public string WhatsappName { get; set; } = null!;
        public Person Person { get; set; } = null!;
    }
}