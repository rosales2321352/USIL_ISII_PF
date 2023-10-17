using System.ComponentModel.DataAnnotations;

namespace WebApp.Data
{
    public class Message
    {
        public string MessageID { get; set; } = null!;
        public DateTime Timestamp { get; set; }
        public string Type {get; set;} = null!;
        public string Text {get; set;} = null!;
        public string WhatsappID { get; set; } = null!;
        public virtual WhatsappData WhatsappData {get; set;} = null!;
    }
}