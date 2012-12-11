using System;
using AutoMapper;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Infrastructure.Mappings
{
    public class MailTemplateProfile : Profile
    {
        protected override void Configure()
        {
            base.Configure();
            CreateMap<MailTemplate, ListMailTemplateModel>();
            CreateMap<MailTemplate, DetailsMailTemplateModel>();

            CreateMap<MailTemplate, CreateMailTemplateModel>();
            CreateMap<CreateMailTemplateModel, MailTemplate>()
                .ForMember(d => d.Id, c => c.Ignore());

            CreateMap<MailTemplate, EditMailTemplateModel>();

            CreateMap<EditMailTemplateModel, MailTemplate>()
                .ForMember(d => d.Id, c => c.Ignore());
        }
    }
}