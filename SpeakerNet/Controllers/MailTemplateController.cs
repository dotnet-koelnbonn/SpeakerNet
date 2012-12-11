using System;
using System.Web.Mvc;
using SpeakerNet.FilterAttributes;
using SpeakerNet.Services;
using SpeakerNet.ViewModels;

namespace SpeakerNet.Controllers
{
    [AdminOnly]
    public class MailTemplateController : SpeakerNetController
    {
        private readonly IMailTemplateService service;

        public MailTemplateController (IMailTemplateService service)
        {
            this.service = service;
        }
        //
        // GET: /MailTemplate/

        public ActionResult Index()
        {
            return View(service.GetListMailTemplateModel());
        }

        //
        // GET: /MailTemplate/Details/5

        public ActionResult Details(Guid id)
        {
            var model = service.FindDetailsMailTemplateModel(id);
            if (model==null)
                return new HttpNotFoundResult();
            model.Body = model.Body.Replace("\r\n", "<br />").Replace("\n", "<br />");
            return View(model);
        }

        //
        // GET: /MailTemplate/Create

        public ActionResult Create()
        {
            return View(new CreateMailTemplateModel());
        } 

        //
        // POST: /MailTemplate/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateMailTemplateModel model)
        {
            if (ModelState.IsValid)
            {
                if (service.CreateMailTemplate(model))
                {
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        
        //
        // GET: /MailTemplate/Edit/5
 
        public ActionResult Edit(Guid id)
        {
            var model = service.FindEditMailTemplateModel(id);
            if (model == null)
                return new HttpNotFoundResult();
            return View(model);
        }

        //
        // POST: /MailTemplate/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, EditMailTemplateModel model)
        {
            if (ModelState.IsValid)
            {
                if (service.UpdateMailTemplate(id, model))
                {
                    return RedirectToAction("Details", new { id });
                }
            }
            return View(model);
        }
    }
}
