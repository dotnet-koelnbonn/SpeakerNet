using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using SpeakerNet.Properties;

namespace SpeakerNet.Models.Views
{
    public class CreateSpeakerModel
    {
        [Required]
        [Display(ResourceType = typeof(SpeakertNetStrings), Name = "Speaker_Salutation")]
        public string Salutation { get; set; }

        [Required]
        [Display(ResourceType = typeof(SpeakertNetStrings), Name = "Speaker_FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Display(ResourceType = typeof(SpeakertNetStrings), Name = "Speaker_LastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(SpeakertNetStrings), Name = "Speaker_EMail")]
        public string EMail { get; set; }
    }
}