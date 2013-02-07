namespace SpeakerNet.Models
{
    public class Vote
    {
        public int SessionId { get; private set; }
        public int WebUserId { get; private set; }
        public Session Session { get; private set; }
        public WebUser WebUser { get; private set; }
        public int Points { get; set; }
    }
}