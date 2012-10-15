using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class CreateEventModel
    {
        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}