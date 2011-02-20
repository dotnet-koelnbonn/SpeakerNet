using System;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public class SpeakerPictureService : ISpeakerPictureService
    {
        private readonly IRepository<SpeakerPicture> _repository;

        public SpeakerPictureService(IRepository<SpeakerPicture> repository)
        {
            _repository = repository;
        }

        public SpeakerPicture TryGetPicture(Guid speakerId)
        {
            return _repository.Entities.FirstOrDefault(sp => sp.Speaker.Id == speakerId && sp.CurrentPicture==true);
        }
    }
}