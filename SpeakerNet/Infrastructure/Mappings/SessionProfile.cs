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
                .ForMember(d => d.Points, c => c.Ignore());

            CreateMap<Session, SessionVotingDetailModel>()
                .ForMember(d => d.Abstract, c => c.AddFormatter<WikiFormatter>());
        }
    }

    public class WikiFormatter : ValueFormatter<string>
    {
        static readonly WikiEngine _wiki = new WikiEngine();

        protected override string FormatValueCore(string value)
        {
            return _wiki.Render(value);
        }
    }
}