using System;
using System.Collections.Generic;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public interface ISendMailService
    {
        IEnumerable<MailTemplate> GetMailTemplates();
        MailTemplate GetTemplate(Guid id);
        void SendMail(string to, string subject, string body);
    }
}