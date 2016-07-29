namespace Windows.Models.SendGrid
{
    public class EmailMessage
    {
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Destination { get; set; }
    }
}
