using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Extensions;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class SpeakerSessionService : ISpeakerSessionService
    {
        private readonly IRepository<Session> repository;
        private readonly IRepository<Speaker> speakerRepository;
        private readonly IRepository<Event> eventRepository;

        public SpeakerSessionService(IRepository<Session> repository, IRepository<Speaker> speakerRepository,
                                     IRepository<Event> eventRepository)
        {
            this.repository = repository;
            this.speakerRepository = speakerRepository;
            this.eventRepository = eventRepository;
        }

        public SpeakerSessionListModel GetSpeakerSessionList(Guid speakerId)
        {
            var speaker = GetSpeaker(speakerId);
            var sessions = repository.Entities.Where(s => s.Speaker.Id == speaker.Id).ToList();
            var model = speaker.MapFrom<Speaker, SpeakerSessionListModel>();
            model.Sessions = sessions.MapFrom<Session, SpeakerSessionIndexModel>();
            return model;
        }

        private Speaker GetSpeaker(Guid speakerId)
        {
            return speakerRepository.Entities
                .Single(s => s.Id == speakerId);
        }

        private Event GetEvent(int eventId)
        {
            return eventRepository.Entities.Single(e => e.Id == eventId);
        }

        public void CreateSession(Guid speakerId, CreateSessionModel model)
        {
            var speaker = GetSpeaker(speakerId);
            var theEvent = GetEvent(model.EventId);
            var session = Session.Create(model.Name, model.Abstract, model.Level, model.Duration);
            session.Speaker = speaker;
            session.Event = theEvent;
            repository.Add(session);
            repository.SaveChanges();
        }

        public IEnumerable<DetailsEventModel> GetEventList()
        {
            return eventRepository.Entities
                .OrderBy(e => e.Name)
                .ToList()
                .MapFrom<Event, DetailsEventModel>();
        }

        public EditSessionModel GetEditSessionModel(Guid speakerId, int sessionId)
        {
            var session = GetSession(speakerId, sessionId);
            return session.MapFrom<Session, EditSessionModel>();
        }

        public void UpdateSession(Guid speakerId, int sessionId, EditSessionModel model)
        {
            var session = GetSession(speakerId, sessionId);
            var theEvent = GetEvent(model.EventId);
            session.Event = theEvent;
            model.MapTo(session);
            repository.SaveChanges();
        }

        public DisplaySessionModel GetDisplaySessionModel(Guid speakerId, int sessionId)
        {
            return GetSession(speakerId, sessionId).MapFrom<Session, DisplaySessionModel>();
        }

        private Session GetSession(Guid speakerId, int sessionId)
        {
            var query = from ss in repository.Entities
                        where ss.Id == sessionId && ss.Speaker.Id == speakerId
                        select ss;
            return query.Single();
        }
    }
}