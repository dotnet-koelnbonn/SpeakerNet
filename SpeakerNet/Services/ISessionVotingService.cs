using System.Collections.Generic;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;
using Aperea.Infrastructure.Mappings;

namespace SpeakerNet.Services
{
    public interface ISessionVotingService {
        IEnumerable<ListSessionVotingModel> GetListSessionVotingModel();
        SessionVotingDetailModel GetSessionDetailModel(int id);
    }

    public class SessionVotingService : ISessionVotingService
    {
        readonly IRepository<Session> sessionRepository;

        public SessionVotingService(IRepository<Session> sessionRepository)
        {
            this.sessionRepository = sessionRepository;
        }

        public IEnumerable<ListSessionVotingModel> GetListSessionVotingModel()
        {
            return sessionRepository.Include("Speaker").MapTo<IEnumerable<ListSessionVotingModel>>();
        }

        public SessionVotingDetailModel GetSessionDetailModel(int id)
        {
            return sessionRepository.Entities.Single(s => s.Id == id).MapTo<SessionVotingDetailModel>();
        }
    }
}