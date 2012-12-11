using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class ListMailTemplateModel {
        [Key]
        public Guid Id { get; set; }

        public string Description { get; set; }
    }
}