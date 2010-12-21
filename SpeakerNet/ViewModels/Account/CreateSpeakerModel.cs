using System.ComponentModel.DataAnnotations;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class CreateSpeakerModel
    {
        [Required]
        [Label("Speaker_Salutation")]
        public string Salutation { get; set; }

        [Required]
        [Label("Speaker_FirstName")]
        public string FirstName { get; set; }

        [Required]
        [Label("Speaker_LastName")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Label("Contact_EMail")]
        public string EMail { get; set; }
    }
}