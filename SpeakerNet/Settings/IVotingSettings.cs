namespace SpeakerNet.Settings
{
    public interface IVotingSettings
    {
        int PointsPerUser { get; }
        int PointsPerVote { get; }
    }
}