using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public interface ISendMailService
    {
        IEnumerable<MailTemplate> GetMailTemplates();
        MailTemplate GetTemplate(Guid id);
        void SendMail(string to, string subject, string body);
        string GetSpeakerUrl(Guid speakerId, HttpRequestBase httpRequest, UrlHelper urlHelper);
        void SendMailToAll(Guid templateId, HttpRequestBase request, UrlHelper url);
    }
}