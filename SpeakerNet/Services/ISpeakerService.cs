using System;
using System.Collections.Generic;
using System.Web.Mvc;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface ISpeakerService
    {
        IEnumerable<SpeakerListModel> GetSpeakerList();
        bool CreateSpeaker(CreateSpeakerModel model);
        Speaker GetSpeaker(Guid speakerId);
        void UpdateSpeaker(Guid speakerId, SpeakerEditModel model);
    }
}