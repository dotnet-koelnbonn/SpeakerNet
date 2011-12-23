using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class SpeakerPicture
    {
        public int Id { get; set; }
        [Required]
        public Speaker Speaker { get; set; }

        [Required]
        [MaxLength]
        public byte[] Picture { get; set; }
        
        [Required]
        public bool CurrentPicture { get; set; }

        [Required]
        [StringLength(64)]
        public string ContentType { get; set; }

        [StringLength(256)]
        [Required]
        public string FileName { get; set; }
    }
}