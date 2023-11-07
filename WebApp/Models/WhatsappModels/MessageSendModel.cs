using Newtonsoft.Json;
namespace WebApp.Models
{

    public class SendMessageRequest
    {
        [JsonProperty("messaging_product")]
        public string MessagingProduct { get; set; } = null!;

        [JsonProperty("recipient_type")]
        public string RecipientType { get; set; } = null!;
        [JsonProperty("to")]
        public string To { get; set; } = null!;
        [JsonProperty("type")]
        public string Type { get; set; } = null!;
        [JsonProperty("text")]
        public TextContent Text { get; set; } = null!;

        public class TextContent
        {
            [JsonProperty("preview_url")]
            public bool PreviewUrl { get; set; }
            [JsonProperty("body")]
            public string Body { get; set; } = null!;
        }
    }
}