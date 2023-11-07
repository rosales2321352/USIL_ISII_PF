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

}