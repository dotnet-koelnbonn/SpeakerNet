using System;
using Aperea.Settings;

namespace SpeakerNet.Settings
{
    public class VotingSessions : IVotingSessions
    {
        readonly IApplicationSettings settings;

        public VotingSessions(IApplicationSettings settings)
        {
            this.settings = settings;
        }

        public int PointsPerUser
        {
            get { return settings.Get("Votes.PointsPerUser", ()=>45); }
        }

        public int PointsPerVote
        {
            get { return settings.Get("Votes.PointsPerVoter", () => 3); }
        }
    }
}