using System;
using AutoMapper;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Initialize
{
    public class MapperInitialize : IBootstrapItem
    {
        public void Execute()
        {
            TwoWayMap<Speaker, SpeakerEditModel>();
            TwoWayMap<Address, AddressModel>();
            TwoWayMap<Contact, ContactModel>();

            Map<Event, DetailsEventModel>();
            Map<Event, EditEventModel>();
            Map<EditEventModel, Event>();

            Map<Session, SessionListModel>();
            Map<Speaker, SpeakerSessionListModel>();
            Map<Session, SpeakerSessionIndexModel>();
            Map<Session, DisplaySessionModel>();
            TwoWayMap<Session, EditSessionModel>();
        }

        private IMappingExpression<T, T1> Map<T, T1>()
        {
            return Mapper.CreateMap<T, T1>();
        }

        private void TwoWayMap<T, T1>()
        {
            Mapper.CreateMap<T, T1>();
            Mapper.CreateMap<T1, T>();
        }
    }
}