using System;
using System.ComponentModel.DataAnnotations;
using SpeakerNet.Attributes;

namespace SpeakerNet.Models
{
    public class Speaker
    {
        public Speaker()
        {
            Address = Address.Create();
            Contact = Contact.Create();
        }

        public static Speaker Create()
        {
            return new Speaker
            {
                Id = Guid.NewGuid()
            };
        }

        public Guid Id { get; private set; }

        [StringLength(16)]
        [Required]
        [Label("Speaker_Salutation")]
        public string Salutation { get; set; }

        [StringLength(128)]
        [Required]
        [Label("Speaker_FirstName")]
        public string FirstName { get; set; }

        [StringLength(128)]
        [Required]
        [Label("Speaker_LastName")]
        public string LastName { get; set; }

        [StringLength(256)]
        [Label("Speaker_Company")]
        public string CompanyName { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public Contact Contact { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Label("Speaker_Engagement")]
        public string Engagement { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Label("Speaker_Biography")]
        public string Biography { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        [Label("Speaker_Topics")]
        public string Topics { get; set; }

    }
}