using System;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public interface ISpeakerPictureService
    {
        SpeakerPicture TryGetPicture(Guid speakerId);
    }
}