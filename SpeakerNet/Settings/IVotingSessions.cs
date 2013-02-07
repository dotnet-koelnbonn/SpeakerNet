namespace SpeakerNet.Settings
{
    public interface IVotingSessions
    {
        int PointsPerUser { get; }
        int PointsPerVote { get; }
    }
}