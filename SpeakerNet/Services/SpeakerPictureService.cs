using System;
using System.Linq;
using Aperea.Data;
using SpeakerNet.Models;

namespace SpeakerNet.Services
{
    public class SpeakerPictureService : ISpeakerPictureService
    {
        private readonly IRepository<SpeakerPicture> repository;

        public SpeakerPictureService(IRepository<SpeakerPicture> repository)
        {
            this.repository = repository;
        }

        public SpeakerPicture TryGetPicture(Guid speakerId)
        {
            return repository.Entities.FirstOrDefault(sp => sp.Speaker.Id == speakerId && sp.CurrentPicture==true);
        }
    }
}