using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class CreateMailTemplateModel
    {
        [StringLength(256)]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(256)]
        public string Subject { get; set; }

        [Required]
        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Body { get; set; }
    }
}