using System.Collections.Generic;
using SpeakerNet.Controllers;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface ISessionVotingService {
        IEnumerable<ListSessionVotingModel> GetListSessionVotingModel();
    }
}