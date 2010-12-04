using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface ISpeakerSessionService
    {
        SpeakerSessionListModel GetSpeakerSessionList(Guid speakerId);
        void CreateSession(Guid speakerId, CreateSessionModel model);
        IEnumerable<DetailsEventModel> GetEventList();
        EditSessionModel GetEditSessionModel(Guid speakerId, int sessionId);
        void UpdateSession(Guid speakerId, int sessionId, EditSessionModel model);
        DisplaySessionModel GetDisplaySessionModel(Guid speakerId, int sessionId);
    }
}