using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Speaker
    {
        private Speaker()
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
        public string Salutation { get; set; }

        [StringLength(128)]
        [Required]
        public string FirstName { get; set; }

        [StringLength(128)]
        [Required]
        public string LastName { get; set; }

        [StringLength(256)]
        public string CompanyName { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public Contact Contact { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Engagement { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        public string Biography { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        public string Topics { get; set; }

    }
}