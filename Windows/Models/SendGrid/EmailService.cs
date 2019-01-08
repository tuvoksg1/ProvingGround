using System;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Windows.Models.SendGrid
{
    public class EmailService
    {
        public EmailService(MailServiceInfo mailInfo)
        {
            MailAccount = mailInfo.MailAccount;
            Password = mailInfo.Password;
            SendAddress = mailInfo.SendAddress;
            DisplayName = mailInfo.DisplayName;
            Host = mailInfo.Host;
            Timeout = mailInfo.Timeout;
            PortNumber = mailInfo.PortNumber;
        }

        private string Host { get; }
        private string MailAccount { get; }
        private string Password { get; }
        private string SendAddress { get; }
        private string DisplayName { get; }
        private int Timeout { get; }
        private int PortNumber { get; }

        public async Task SendAsync(EmailMessage message)
        {
            await SendEmailAsync(message);
        }

        private async Task SendMailAsync(EmailMessage message)
        {
            var client = new SmtpClient
            {
                Host = Host,
                Timeout = Timeout,
                Port = PortNumber,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(MailAccount, Password)
            };

            var mail = new MailMessage();
            mail.To.Add(new MailAddress(message.Destination));
            mail.From = new MailAddress(SendAddress, DisplayName);
            mail.Subject = message.Subject;
            mail.Body = message.Body;
            mail.BodyEncoding = Encoding.UTF8;

            try
            {
                await client.SendMailAsync(mail);
            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message + " SendGrid probably not configured correctly.");
            }
        }

        private async Task SendEmailAsync(EmailMessage message)
        {
            await Task.Delay(0);
            //dynamic sendGrid = new SendGridAPIClient(MailAccount);

            //var from = new Email(SendAddress);
            //var to = new Email(message.Destination);
            //var content = new Content("text/plain", message.Body);
            //var mail = new Mail(from, message.Subject, to, content);

            //try
            //{
            //    dynamic response = await sendGrid.client.mail.send.post(requestBody: mail.Get());
            //}
            //catch (Exception ex)
            //{
            //    Trace.TraceError(ex.Message + " SendGrid probably not configured correctly.");
            //}
        }
    }
}
