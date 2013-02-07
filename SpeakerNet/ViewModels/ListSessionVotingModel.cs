using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class ListSessionVotingModel {
        [Key]
        public int Id { get; set; }
        public string SessionName { get; set; }
        public int Points { get; set; }
        public string WebUserName { get; set; }
    }
}