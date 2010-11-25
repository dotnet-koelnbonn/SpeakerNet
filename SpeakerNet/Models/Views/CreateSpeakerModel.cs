using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using SpeakerNet.Attributes;
using SpeakerNet.Extensions;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Properties;

namespace SpeakerNet.Models.Views
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