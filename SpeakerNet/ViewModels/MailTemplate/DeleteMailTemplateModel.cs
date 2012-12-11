using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class DeleteMailTemplateModel {
        [Key]
        public Guid Id { get; set; }
    }
}