using System.ComponentModel.DataAnnotations;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class ContactModel
    {
        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]
        [Label("Contact_Phone")]
        public string Phone { get; set; }

        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]
        [Label("Contact_Fax")]
        public string Fax { get; set; }

        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        [Required]
        [Label("Contact_EMail")]
        public string EMail { get; set; }

        [StringLength(256)]
        [DataType(DataType.Url)]
        [Label("Contact_Homepage")]
        public string Homepage { get; set; }
    }
}