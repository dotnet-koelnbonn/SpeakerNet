using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Contact
    {
        private Contact()
        {
            
        }
        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [StringLength(32)]
        [DataType(DataType.PhoneNumber)]
        public string Fax { get; set; }

        [StringLength(128)]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string EMail { get; set; }

        [StringLength(256)]
        [DataType(DataType.Url)]
        public string Homepage { get; set; }

        public static Contact Create()
        {
            return new Contact();
        }
    }
}