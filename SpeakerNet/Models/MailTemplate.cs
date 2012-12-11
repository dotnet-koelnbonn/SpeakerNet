using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class MailTemplate
    {
        public MailTemplate()
        {
            Id = Guid.NewGuid();
        }
        [Required]
        [Key]
        public Guid Id { get; private set; }

        [StringLength(256)]
        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(256)]
        public string Subject { get; set; }

        [Required]
        [StringLength(4000)]
        public string Body { get; set; }
    }
}