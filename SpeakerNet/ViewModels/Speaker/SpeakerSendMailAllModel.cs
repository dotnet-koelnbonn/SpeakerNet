using System;
using System.Web.Mvc;

namespace SpeakerNet.ViewModels
{
    public class SpeakerSendMailAllModel
    {
        public SpeakerSendMailAllModel()
        {
            TemplateId = Guid.Empty;
        }
        public Guid TemplateId { get; set; }
        public SelectList TemplateList { get; set; }
    }
}