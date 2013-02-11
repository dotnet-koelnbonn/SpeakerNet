using System;
using System.Collections.Generic;
using System.Linq;
using Aperea.Infrastructure.Mappings;
using Microsoft.AspNet.SignalR;
using SpeakerNet.Data;
using SpeakerNet.Hubs;
using SpeakerNet.Models;
using SpeakerNet.Settings;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
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
            UpdateSessionResult(id);
            return Votes(user.Id);
        }

        int CountVotes(int userId)
        {
            var query = voteRepository.Entities.Where(v => v.WebUserId == userId).ToList();
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

        void UpdateSessionResult(int sessionId)
        {
            var query = from v in voteRepository.Entities
                        where v.Points > 0 && v.SessionId == sessionId
                        group v by v.Session
                        into s
                        select new ListSessionVotingModel() {
                            Id = s.Key.Id,
                            Name = s.Key.Name,
                            SpeakerId = s.Key.Speaker.Id,
                            SpeakerFirstName = s.Key.Speaker.FirstName,
                            SpeakerLastName = s.Key.Speaker.LastName,
                            Duration = s.Key.Duration,
                            Points = s.Sum(v => v.Points)
                        };
            var result = query.SingleOrDefault();
            if (result == null) {
                result = new ListSessionVotingModel {
                    Id = sessionId,
                    Points = 0
                };
            }
            var context = GlobalHost.ConnectionManager.GetHubContext<VotingResultHub>();
            context.Clients.All.updateSession(new
            {
                Sessions =new[]{result},
                Voters = GetSessionVoters()
            });
        }

        public IEnumerable<ListSessionVotingModel> GetSessionVotesSummary()
        {
            var query = from v in voteRepository.Entities
                        where v.Points > 0
                        group v by v.Session
                        into s
                        select new ListSessionVotingModel() {
                            Id = s.Key.Id,
                            Name = s.Key.Name,
                            SpeakerId = s.Key.Speaker.Id,
                            SpeakerFirstName = s.Key.Speaker.FirstName,
                            SpeakerLastName = s.Key.Speaker.LastName,
                            Duration = s.Key.Duration,
                            Points = s.Sum(v => v.Points)
                        };
            return query.ToArray().OrderByDescending(v => v.Points);
        }

        public IEnumerable<SessionVoters> GetSessionVoters()
        {
            var query = from v in voteRepository.Entities
                        group v by v.WebUser
                        into s
                        select new SessionVoters() {
                            Name = s.Key.Name,
                            Points = s.Sum(v => v.Points)
                        };
            return query.ToArray();
        }
    }
}