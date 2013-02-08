namespace SpeakerNet.ViewModels
{
    public class SessionVotingDetailModel
    {
        public int Id { get; set; }

        public string Abstract { get; set; }

        public string Name { get; set; }

        public int Level { get; set; }

        public int Duration { get; set; }


        public bool Selected { get; set; }
    }
}