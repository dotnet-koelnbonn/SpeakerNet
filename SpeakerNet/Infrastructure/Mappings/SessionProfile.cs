using System.Web;
using AutoMapper;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;
using WikiPlex;

namespace SpeakerNet.Infrastructure.Mappings
{
    public class SessionProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<Session, ListSessionVotingModel>()
                .ForMember(d => d.Abstract, c => c.AddFormatter<WikiFormatter>())
                .ForMember(d => d.Points, c => c.Ignore())
                .ForMember(d => d.SpeakerName, c => c.MapFrom(s => s.Speaker.FullName));

            CreateMap<Session, SessionVotingDetailModel>()
                .ForMember(d => d.Abstract, c => c.AddFormatter<WikiFormatter>());
        }
    }

    public class WikiFormatter : ValueFormatter<string>
    {
        readonly WikiEngine wiki = new WikiEngine();

        protected override string FormatValueCore(string value)
        {
            return wiki.Render(value);
        }
    }
}