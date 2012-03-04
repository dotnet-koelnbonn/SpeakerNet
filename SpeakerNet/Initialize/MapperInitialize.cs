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

            Map<Event, DetailsEventModel>()
                .ForMember(d => d.Session, c => c.Ignore());
            Map<Event, EditEventModel>();
            Map<EditEventModel, Event>();
            Map<SpeakerPicture, PictureUploadShowModel>()
                .ForMember(c => c.Picture, c => c.Ignore());

            Map<Session, SessionListModel>();
            Map<Speaker, SpeakerSessionListModel>()
                                .ForMember(d => d.Sessions, c => c.Ignore());

            Map<Session, SpeakerSessionIndexModel>();
            Map<Session, DisplaySessionModel>()
                .ForMember(c => c.ShowSessionSelection, c => c.Ignore());

                        Map<Session, EditSessionModel>()
                                            .ForMember(c => c.EventSelectList, c => c.Ignore())
                                            .ForMember(c => c.LevelSelectList, c => c.Ignore())
                                            .ForMember(c => c.DurationSelectList, c => c.Ignore());

                        Map<EditSessionModel, Session>()
                                            .ForMember(c => c.Speaker, c => c.Ignore())
                                            .ForMember(c => c.Event, c => c.Ignore())
                                            .ForMember(c => c.Selected, c => c.Ignore());

            Mapper.CreateMap<Speaker, SpeakerTollModel>()
                .ForMember(t => t.Plz, m => m.MapFrom(s => s.Address.ZipCode))
                .ForMember(t => t.Salutation, m => m.Ignore());
            Mapper.AssertConfigurationIsValid();
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