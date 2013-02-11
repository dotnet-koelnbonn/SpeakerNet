using System;
using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class ListSessionVotingModel {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public Guid SpeakerId { get; set; }
        public string SpeakerFirstName { get; set; }
        public string SpeakerLastName { get; set; }
        public string SpeakerCompanyName { get; set; }
        public int Level { get; set; }
        public int Duration { get; set; }
        public int Points { get; set; }
    }
}