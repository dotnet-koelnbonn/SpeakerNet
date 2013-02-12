using System;
using System.Collections.Generic;
using System.Linq;
using Aperea.Data;
using SpeakerNet.Extensions;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public class EventService : IEventService
    {
        private readonly IRepository<Event> repository;
        private readonly IRepository<Session> sessionRepository;

        public EventService(IRepository<Event> repository, IRepository<Session> sessionRepository)
        {
            this.repository = repository;
            this.sessionRepository = sessionRepository;
        }

        public IEnumerable<EventListModel> GetEventList()
        {
            var query = from evt in repository.Entities
                               join session in sessionRepository.Entities on evt.Id equals session.Event.Id into sessions
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
            repository.Add(newEvent);
            repository.SaveChanges();
        }

        public EditEventModel GetEditEventModel(int eventId)
        {
            return GetEvent(eventId).MapFrom<Event, EditEventModel>();
        }

        private Event GetEvent(int eventId)
        {
            return repository.Entities.Single(e => e.Id == eventId);
        }

        public void UpdateEvent(int eventId, EditEventModel model)
        {
            var evt = GetEvent(eventId);
            model.MapTo(evt);
            repository.SaveChanges();
        }

        public DetailsEventModel GetDetailsEventModel(int eventId)
        {
            var model= GetEvent(eventId).MapFrom<Event, DetailsEventModel>();
            var sessions = from s in sessionRepository.Entities
                           where s.Event.Id == eventId
                           orderby s.Selected descending, s.Duration, s.Speaker.LastName, s.Speaker.FirstName
                           select new SessionListModel {
                               Id = s.Id,
                               SpeakerId = s.Speaker.Id,
                               Name = s.Name,
                               Level = s.Level,
                               Duration = s.Duration,
                               SpeakerFullName = s.Speaker.FirstName + " " + s.Speaker.LastName,
                               Selected = s.Selected
                           };
            model.Session = sessions.ToList();
            return model;
        }
    }
}