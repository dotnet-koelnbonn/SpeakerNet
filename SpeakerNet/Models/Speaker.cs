using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Speaker
    {
        protected Speaker()
        {
            Address = Address.Create();
            Contact = Contact.Create();
        }


        public static Speaker Create(string salutation, string firstname, string lastname, string email)
        {
            var speaker = new Speaker {
                Id = Guid.NewGuid(),
                Salutation = salutation,
                FirstName = firstname,
                LastName = lastname,
                Contact = {EMail = email}
            };
            return speaker;
        }

        public Guid Id { get; private set; }

        [Required]
        [StringLength(16)]
        public string Salutation { get; set; }

        [Required]
        [StringLength(128)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(128)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

        [StringLength(256)]
        public string CompanyName { get; set; }

        [Required]
        public Address Address { get; set; }

        [Required]
        public Contact Contact { get; set; }

        [StringLength(4000)]
        public string Engagement { get; set; }

        [StringLength(4000)]
        public string Biography { get; set; }

        [StringLength(4000)]
        public string Topics { get; set; }
    }
}