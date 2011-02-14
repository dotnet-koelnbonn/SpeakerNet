using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Extensions;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> _repository;
        private readonly IRepository<Session> _sessionRepository;

        public SpeakerService(IRepository<Speaker> repository, IRepository<Session> sessionRepository)
        {
            _repository = repository;
            _sessionRepository = sessionRepository;
        }

        public IEnumerable<SpeakerListModel> GetSpeakerList()
        {

            var speakers = from speaker in _repository.Entities
                                   join session in _sessionRepository.Entities on speaker.Id equals  session.Speaker.Id into sessions
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
            _repository.Add(speaker);
            _repository.SaveChanges();
            return true;
        }

        public Speaker GetSpeaker(Guid speakerId)
        {
            return _repository.Entities.Where(e => e.Id == speakerId).Single();
        }

        public void UpdateSpeaker(Guid speakerId, SpeakerEditModel model)
        {
            var speaker = GetSpeaker(speakerId);
            model.MapTo(speaker);
            _repository.SaveChanges();
        }
    }
}