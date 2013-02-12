using System;
using System.Collections.Generic;
using System.Linq;
using Aperea.Data;
using SpeakerNet.Extensions;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> repository;
        private readonly IRepository<Session> sessionRepository;

        public SpeakerService(IRepository<Speaker> repository, IRepository<Session> sessionRepository)
        {
            this.repository = repository;
            this.sessionRepository = sessionRepository;
        }

        public IEnumerable<SpeakerListModel> GetSpeakerList()
        {

            var speakers = from speaker in repository.Entities
                                   join session in sessionRepository.Entities on speaker.Id equals  session.Speaker.Id into sessions
                           orderby speaker.LastName , speaker.FirstName 
                           select new SpeakerListModel {
                               Id = speaker.Id,
                               Fullname = speaker.LastName + ", " + speaker.FirstName,
                               SessionCount = sessions.Count()
                           };
            return speakers.ToList();
        }

        public bool CreateSpeaker(CreateSpeakerModel model)
        {
            var speaker = Speaker.Create(model.Salutation,model.FirstName,model.LastName,model.EMail);
            repository.Add(speaker);
            repository.SaveChanges();
            return true;
        }

        public Speaker GetSpeaker(Guid speakerId)
        {
            return repository.Entities.Single(e => e.Id == speakerId);
        }

        public void UpdateSpeaker(Guid speakerId, SpeakerEditModel model)
        {
            var speaker = GetSpeaker(speakerId);
            model.MapTo(speaker);
            repository.SaveChanges();
        }
    }
}