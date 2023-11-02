namespace WebApp.Models
{
    public class MessageRecieved
    {
        public string Text { get; set; } = null!;
        public string WhatsappID { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;

        public MessageRecieved(string text, string id, string number)
        {
            Text = text;
            WhatsappID = id;
            PhoneNumber = number;
        }

        public MessageRecieved(){}

        public void PrintMessage()
        {
            Console.WriteLine(Text);
            Console.WriteLine(WhatsappID);
            Console.WriteLine(PhoneNumber);
        }
    }

    public class WebHookResponseModel
    {
        public Entry[] entry { get; set; }
    }
    public class Entry
    {
        public Change[] changes { get; set; }
    }
    public class Change
    {
        public Value value { get; set; }
    }
    public class Value
    {
        public int ad_id { get; set; }
        public long form_id { get; set; }
        public long leadgen_id { get; set; }
        public int created_time { get; set; }
        public long page_id { get; set; }
        public int adgroup_id { get; set; }
        public Messages[] messages { get; set; }
    }
    public class Messages
    {
        public string id { get; set; }
        public string from { get; set; }
        public Text text { get; set; }
    }
    public class Text
    {
        public string body { get; set; }
    }
}