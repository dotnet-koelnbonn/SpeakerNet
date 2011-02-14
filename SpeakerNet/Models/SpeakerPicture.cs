using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class SpeakerPicture
    {
        public int Id { get; set; }
        [Required]
        public Speaker Speaker { get; set; }
        [Required]
        public byte[] Picture;
    }
}