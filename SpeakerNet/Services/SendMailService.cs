using System;
using System.Collections.Generic;
using System.Net.Mail;
using Aperea.Data;
using SpeakerNet.Models;
using SpeakerNet.Settings;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SpeakerNet.Extensions;

namespace SpeakerNet.Services
{
    public class SendMailService : ISendMailService
    {
        readonly IMailSettings settings;
        readonly IRepository<MailTemplate> repository;
        private readonly ISpeakerService _speakerService;

        public SendMailService(IMailSettings settings, IRepository<MailTemplate> repository, ISpeakerService speakerService)
        {
            this.settings = settings;
            this.repository = repository;
            _speakerService = speakerService;
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

        /// <inheritdoc />
        public void SendMailToAll(Guid templateId, HttpRequestBase request, UrlHelper url)
        {
            var speakers = _speakerService.GetAllSpeakers();
            var template = GetTemplate(templateId);
            foreach (var speaker in speakers)
            {
                var model = new {
                    speaker.FirstName,
                    speaker.LastName,
                    SpeakerUrl = GetSpeakerUrl(speaker.Id, request, url)
                };
                var subject = template.Subject.NamedFormat(model);
                var body = template.Body.NamedFormat(model);
                SendMail(speaker.Contact.EMail, subject, body);
            }
        }

        public string GetSpeakerUrl(Guid speakerId, HttpRequestBase httpRequest, UrlHelper urlHelper)
        {
            var actionPath = urlHelper.Action("Details", "Speaker", new {Id = speakerId});

            return $"{httpRequest.Url.Scheme}://{httpRequest.Url.Authority}{actionPath}";
        }
    }
}