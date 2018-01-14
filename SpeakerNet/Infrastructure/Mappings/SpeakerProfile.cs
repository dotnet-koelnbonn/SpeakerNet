using AutoMapper;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Infrastructure.Mappings
{
    public class SpeakerProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();

            CreateMap<Speaker, SpeakerSendMailModel>()
                .ForMember(d => d.Body, c => c.Ignore())
                .ForMember(d => d.Subject, c => c.Ignore())
                .ForMember(d => d.TemplateList, c => c.Ignore())
                .ForMember(d => d.TemplateId, c => c.Ignore());

            CreateMap<Speaker, SpeakerEditModel>();
            CreateMap<SpeakerEditModel, Speaker>();

            CreateMap<Speaker, SpeakerSessionListModel>()
                    .ForMember(d => d.Sessions, c => c.Ignore());
        }
    }
}