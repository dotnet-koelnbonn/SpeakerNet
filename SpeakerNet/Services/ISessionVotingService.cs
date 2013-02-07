using System.Collections.Generic;
using System.ComponentModel;
using SpeakerNet.Controllers;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface ISessionVotingService {
        IEnumerable<ListSessionVotingModel> GetListSessionVotingModel();
    }

    public class SessionVotingService : ISessionVotingService
    {
        public IEnumerable<ListSessionVotingModel> GetListSessionVotingModel()
        {
            return new BindingList<ListSessionVotingModel>();
        }
    }
}