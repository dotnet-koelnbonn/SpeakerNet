using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class EditEventModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(128)]
        public string Name { get; set; }
    }
}