using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Hubs
{
    [HubName("votingResult")]
    public class VotingResultHub : Hub
    {
        public void updateSession(ListSessionVotingModel model)
         {
             Clients.All.updateSession(model);
         }
    }
}