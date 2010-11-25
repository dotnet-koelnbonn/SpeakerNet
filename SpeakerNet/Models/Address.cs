using System;
using System.ComponentModel.DataAnnotations;
using SpeakerNet.Attributes;

namespace SpeakerNet.Models
{
    public class Address
    {
        private Address()
        {
            
        }
        [StringLength(128)]
        [Label("Address_Street")]
        public string Street { get; set; }
        [StringLength(6)]
        [Label("Address_ZipCode")]
        public string ZipCode { get; set; }
        [StringLength(128)]
        [Label("Address_City")]
        public string City { get; set; }
        [StringLength(128)]
        [Label("Address_Country")]
        public string Country { get; set; }

        public  static  Address Create()
        {
            return new Address();
        }
    }
}
