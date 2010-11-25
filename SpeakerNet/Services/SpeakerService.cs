using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using SpeakerNet.Data;
using SpeakerNet.Models;
using SpeakerNet.Models.Views;

namespace SpeakerNet.Services
{
    public class SpeakerService : ISpeakerService
    {
        private readonly IRepository<Speaker> speakerRepository;

        public SpeakerService(IRepository<Speaker> speakerRepository)
        {
            this.speakerRepository = speakerRepository;
        }

        public IEnumerable<SpeakerListModel> GetSpeakerList()
        {
            var speakers = from s in speakerRepository.Entities
                           orderby s.LastName , s.FirstName
                           select new SpeakerListModel
                           {
                               Id = s.Id,
                               Fullname = s.LastName + ", " + s.FirstName
                           };
            return speakers.ToList();
        }

        public bool CreateSpeaker(CreateSpeakerModel model)
        {
            var speaker = Speaker.Create();
            speaker.FirstName = model.FirstName;
            speaker.LastName = model.LastName;
            speaker.Salutation = model.Salutation;
            speaker.Contact.EMail = model.EMail;
            speakerRepository.Add(speaker);
            speakerRepository.SaveChanges();
            return true;
        }

        public Speaker GetSpeaker(Guid id)
        {
            return speakerRepository.Entities.Where(e => e.Id == id).Single();
        }

        public void Update()
        {
            speakerRepository.SaveChanges();
        }
    }
}