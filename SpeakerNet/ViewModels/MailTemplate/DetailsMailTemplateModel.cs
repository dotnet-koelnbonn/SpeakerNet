using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class DetailsMailTemplateModel {
        [Key]
        public Guid Id { get;  set; }

        public string Description { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }
    }
}