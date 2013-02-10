using System.Collections.Generic;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Models;
using SpeakerNet.Settings;
using SpeakerNet.ViewModels;
using Aperea.Infrastructure.Mappings;

namespace SpeakerNet.Services
{
    public interface ISessionVotingService
    {
        IEnumerable<ListSessionVotingModel> GetListSessionVotingModel();
        SessionVotingDetailModel GetSessionDetailModel(int id);
        IEnumerable<VoteResult> Vote(int id, int points);
        IEnumerable<VoteResult> Votes();
    }

    public class VoteResult
    {
        public int SessionId { get; set; }
        public int Points { get; set; }
    }

    public class SessionVotingService : ISessionVotingService
    {
        readonly IRepository<Session> sessionRepository;
        readonly ICurrentWebUser currentWeb;
        readonly IRepository<Vote> voteRepository;
        readonly IVotingSettings settings;

        public SessionVotingService(IRepository<Session> sessionRepository,
                                    ICurrentWebUser currentWeb,
                                    IRepository<Vote> voteRepository,
                                    IVotingSettings settings)
        {
            this.sessionRepository = sessionRepository;
            this.currentWeb = currentWeb;
            this.voteRepository = voteRepository;
            this.settings = settings;
        }

        public IEnumerable<ListSessionVotingModel> GetListSessionVotingModel()
        {
            return sessionRepository.Entities.Project().ToArray<ListSessionVotingModel>();
        }

        public SessionVotingDetailModel GetSessionDetailModel(int id)
        {
            return sessionRepository.Entities.Single(s => s.Id == id).MapTo<SessionVotingDetailModel>();
        }

        public IEnumerable<VoteResult> Vote(int id, int points)
        {
            var user = currentWeb.User;
            var voteCount = CountVotes(user.Id);
            var vote = voteRepository.Entities.SingleOrDefault(v => v.SessionId == id && v.WebUserId == user.Id);
            if (vote != null) {
                var diffPoints = points - vote.Points;
                if (diffPoints >= 0 && (voteCount + diffPoints) > settings.PointsPerUser) {
                    return new List<VoteResult>();
                }
                vote.Points = points;
                voteRepository.SaveChanges();
            }
            else {
                if ((voteCount + points) > settings.PointsPerUser) {
                    return new List<VoteResult>();
                }
                vote = new Vote(id, user.Id, points);
                voteRepository.Add(vote);
                voteRepository.SaveChanges();
            }
            return Votes(user.Id);
        }

        int CountVotes(int userId)
        {
            var query  = voteRepository.Entities.Where(v => v.WebUserId == userId).ToList();
            return query.Sum(v => v.Points);
        }

        IEnumerable<VoteResult> Votes(int userId)
        {
            var query =
                from v in voteRepository.Entities
                where v.WebUserId == userId
                select new VoteResult {
                    SessionId = v.SessionId,
                    Points = v.Points
                };
            return query.ToArray();
        }

        public IEnumerable<VoteResult> Votes()
        {
            var user = currentWeb.User;
            return Votes(user.Id);
        }
    }
}