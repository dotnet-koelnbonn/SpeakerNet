using System.ComponentModel.DataAnnotations;

namespace SpeakerNet.ViewModels
{
    public class ListSessionVotingModel {
        [Key]
        public int Id { get; set; }
        public int SessionId { get; set; }
        public string SessionName { get; set; }
        public int SessionDuration { get; set; }
        public int WebUserId { get; set; }
        public string WebUserName { get; set; }
        public int Points { get; set; }
    }
}