namespace Windows.Models.SendGrid
{
    public class MailServiceInfo
    {
        public string Host { get; set; }
        public string MailAccount { get; set; }
        public string Password { get; set; }
        public string SendAddress { get; set; }
        public string DisplayName { get; set; }
        public int PortNumber { get; set; }
        public int Timeout { get; set; }
    }
}
