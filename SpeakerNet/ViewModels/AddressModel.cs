using System.ComponentModel.DataAnnotations;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class AddressModel
    {
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
    }
}