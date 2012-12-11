using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net.Mail;
using SpeakerNet.Data;
using SpeakerNet.Models;
using SpeakerNet.Settings;
using System.Linq;

namespace SpeakerNet.Services
{
    public class SendMailService : ISendMailService
    {
        readonly IMailSettings settings;
        readonly IRepository<MailTemplate> repository;

        public SendMailService(IMailSettings settings, IRepository<MailTemplate> repository)
        {
            this.settings = settings;
            this.repository = repository;
        }

        public IEnumerable<MailTemplate> GetMailTemplates()
        {
            return repository.Entities.OrderBy(mt => mt.Description).ToArray();
        }

        public MailTemplate GetTemplate(Guid id)
        {
            return repository.Entities.Single(mt => mt.Id == id);
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