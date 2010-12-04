using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SpeakerNet.Attributes;

namespace SpeakerNet.ViewModels
{
    public class SpeakerEditModel
    {
        [HiddenInput(DisplayValue = false)]
        public Guid Id { get; set; }

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
        public AddressModel Address { get; set; }

        [Required]
        public ContactModel Contact { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Label("Speaker_Engagement")]
        [UIHint("_Wiki")]
        public string Engagement { get; set; }

        [StringLength(4000)]
        [DataType(DataType.MultilineText)]
        [Label("Speaker_Biography")]
        [UIHint("_Wiki")]
        public string Biography { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(4000)]
        [Label("Speaker_Topics")]
        [UIHint("_Wiki")]
        public string Topics { get; set; }

    }
}