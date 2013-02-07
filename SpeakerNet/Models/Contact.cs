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
        public string Phone { get; set; }

        [StringLength(32)]
        public string Fax { get; set; }

        [Required]
        [StringLength(128)]
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