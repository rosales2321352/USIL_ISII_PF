namespace WebApp.Models
{
    public class WebHookResponseModel
    {
        public Entry[] Entry { get; set; } = null!;
    }
    public class Entry
    {
        public string Id { get; set; } = null!;
        public Change[] Changes { get; set; } = null!;
    }
    public class Change
    {
        public Value Value { get; set; } = null!;
    }
    public class Value
    {
        public Messages[] Messages { get; set; } = null!;
        public Contact[] Contacts { get; set; } = null!;
        public Metadata Metadata { get; set; } = null!;
    }
    public class Metadata
    {
        public string Phone_number_id { get; set; } = null!;
    }
    public class Contact
    {
        public string Wa_id { get; set; } = null!;
        public Profile Profile { get; set; } = null!;
    }
    public class Profile
    {
        public string Name { get; set; } = null!;
    }
    public class Messages
    {
        public string Id { get; set; } = null!;
        public string From { get; set; } = null!;
        public string Timestamp { get; set; } = null!;
        public Text Text { get; set; } = null!;
    }
    public class Text
    {
        public string Body { get; set; } = null!;
    }
}


