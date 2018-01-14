using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SpeakerNet.ViewModels
{
    public class SpeakerSendMailModel : SpeakerSendMailAllModel
    {
        public Guid Id { get; set; }

        public string Salutation { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

    }
}