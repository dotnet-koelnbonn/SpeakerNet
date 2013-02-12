using System;
using System.Collections.Generic;
using Aperea.Data;
using SpeakerNet.Models;
using SpeakerNet.ViewModels;
using System.Linq;
using SpeakerNet.Extensions;

namespace SpeakerNet.Services
{
    public class MailTemplateService : IMailTemplateService
    {
        readonly IRepository<MailTemplate> repository;

        public MailTemplateService(IRepository<MailTemplate> repository)
        {
            this.repository = repository;
        }

        public IEnumerable<ListMailTemplateModel> GetListMailTemplateModel()
        {
            var query = from mt in repository.Entities
                        orderby mt.Description
                        select new ListMailTemplateModel() {
                            Id = mt.Id,
                            Description = mt.Description
                        };
            return query.ToArray();
        }

        MailTemplate FindMailTemplate(Guid id)
        {
            return repository.Entities.SingleOrDefault(mt => mt.Id == id);
        }

        public DetailsMailTemplateModel FindDetailsMailTemplateModel(Guid id)
        {
            return FindMailTemplate(id).MapFrom<MailTemplate, DetailsMailTemplateModel>();
        }


        public bool CreateMailTemplate(CreateMailTemplateModel model)
        {
            var newTemplate = model.MapFrom<CreateMailTemplateModel, MailTemplate>();
            repository.Add(newTemplate);
            repository.SaveChanges();
            return true;
        }


        public EditMailTemplateModel FindEditMailTemplateModel(Guid id)
        {
            return FindMailTemplate(id).MapFrom<MailTemplate, EditMailTemplateModel>();
        }

        public bool UpdateMailTemplate(Guid id, EditMailTemplateModel model)
        {
            var currentTemplate = FindMailTemplate(id);
            if (currentTemplate == null)
                return false;
            model.MapTo(currentTemplate);
            repository.SaveChanges();
            return true;
        }

    }
}