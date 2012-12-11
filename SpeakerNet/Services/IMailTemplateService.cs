using System;
using System.Collections.Generic;
using SpeakerNet.Controllers;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Services
{
    public interface IMailTemplateService {
        IEnumerable<ListMailTemplateModel> GetListMailTemplateModel();
        DetailsMailTemplateModel FindDetailsMailTemplateModel(Guid id);
        EditMailTemplateModel FindEditMailTemplateModel(Guid id);

        bool CreateMailTemplate(CreateMailTemplateModel model);
        bool UpdateMailTemplate(Guid id, EditMailTemplateModel model);
    }
}