using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class ListSessionVotingModel {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abstract { get; set; }
        public string SpeakerName { get; set; }
        public int Duration { get; set; }
        public int Points { get; set; }
    }
}