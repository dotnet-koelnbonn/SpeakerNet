using System.Collections.Generic;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface ISessionVotingService
    {
        IEnumerable<ListSessionVotingModel> GetListSessionVotingModel();
        SessionVotingDetailModel GetSessionDetailModel(int id);
        IEnumerable<VoteResult> Vote(int id, int points);
        IEnumerable<VoteResult> Votes();
        IEnumerable<ListSessionVotingModel> GetSessionVotesSummary();
        IEnumerable<SessionVoters> GetSessionVoters();
    }

    public class SessionVoters
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }

    public class VoteResult
    {
        public int SessionId { get; set; }
        public int Points { get; set; }
    }
}