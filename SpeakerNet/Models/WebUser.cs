using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class WebUser
    {
        [Key]
        public int Id { get; private set; }

        [StringLength(64)]
        [Required]
        public string Name { get; private set; }
    }
}