using System;
using System.Configuration;
using System.Net.Mail;

namespace SpeakerNet.Services
{
    public class SendMailService : ISendMailService
    {
        public void SendMail(string to, string subject, string body)
        {
            var message = new MailMessage("orga@dotnet-cologne.de", to, subject, body);
            message.To.Add("orga@dotnet-cologne.de");
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}