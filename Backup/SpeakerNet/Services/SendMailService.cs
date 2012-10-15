using System;
using System.Configuration;
using System.Net.Mail;
using SpeakerNet.Settings;

namespace SpeakerNet.Services
{
    public class SendMailService : ISendMailService
    {
        readonly IMailSettings settings;

        public SendMailService(IMailSettings settings)
        {
            this.settings = settings;
        }

        public void SendMail(string to, string subject, string body)
        {
            var message = new MailMessage(settings.From, to, subject, body);
            message.CC.Add(settings.Cc);
            var smtp = new SmtpClient();
            smtp.Send(message);
        }
    }
}