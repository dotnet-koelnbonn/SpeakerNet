using System;
using System.Collections.Generic;
using System.Linq;
using SpeakerNet.Data;
using SpeakerNet.Extensions;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> _repository;
        private readonly IRepository<Session> _sessionRepository;

        public EventService(IRepository<Event> repository, IRepository<Session> sessionRepository)
        {
            _repository = repository;
            _sessionRepository = sessionRepository;
        }

        public IEnumerable<EventListModel> GetEventList()
        {
            var query = from evt in _repository.Entities
                               join session in _sessionRepository.Entities on evt.Id equals session.Event.Id into sessions
                        orderby evt.Name
                        select new EventListModel {
                            Id=evt.Id,
                            Name = evt.Name,
                            SessionCount = sessions.Count()
                        };
            return query.ToList();
        }

        public void CreateEvent(CreateEventModel model)
        {
            var newEvent = Event.Create(model.Name);
            _repository.Add(newEvent);
            _repository.SaveChanges();
        }

        public EditEventModel GetEditEventModel(int eventId)
        {
            return GetEvent(eventId).MapFrom<Event, EditEventModel>();
        }

        private Event GetEvent(int eventId)
        {
            return _repository.Entities.Single(e => e.Id == eventId);
        }

        public void UpdateEvent(int eventId, EditEventModel model)
        {
            var evt = GetEvent(eventId);
            model.MapTo(evt);
            _repository.SaveChanges();
        }

        public DetailsEventModel GetDetailsEventModel(int eventId)
        {
            var model= GetEvent(eventId).MapFrom<Event, DetailsEventModel>();
            var sessions = from s in _sessionRepository.Entities
                           where s.Event.Id == eventId
                           orderby s.Name
                           select new SessionListModel {
                               Id = s.Id,
                               SpeakerId = s.Speaker.Id,
                               Name = s.Name,
                               Level = s.Level,
                               Duration = s.Duration,
                               SpeakerFullName = s.Speaker.FirstName + " " + s.Speaker.LastName
                           };
            model.Session = sessions.ToList();
            return model;
        }
    }
}