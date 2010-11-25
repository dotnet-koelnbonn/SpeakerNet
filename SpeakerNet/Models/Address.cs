using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.Models
{
    public class Address
    {
        private Address()
        {
            
        }
        [StringLength(128)]
        public string Street { get; set; }
        [StringLength(6)]
        public string ZipCode { get; set; }
        [StringLength(128)]
        public string City { get; set; }
        [StringLength(128)]
        public string Country { get; set; }

        public  static  Address Create()
        {
            return new Address();
        }
    }
}
