using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using StructureMap;

namespace SpeakerNet.Infrastructure.Mvc
{
    public class StructureMapControllerActionInvoker : ControllerActionInvoker
    {
        private readonly IContainer container;

        public StructureMapControllerActionInvoker()
        {
            container = ServiceLocator.Current.GetInstance<IContainer>();
        }

        protected override FilterInfo GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);
            BuildUp(filters.ActionFilters);
            BuildUp(filters.AuthorizationFilters);
            BuildUp(filters.ExceptionFilters);
            BuildUp(filters.ResultFilters);
            return filters;
        }

        protected override ActionResult CreateActionResult(ControllerContext controllerContext,
                                                           ActionDescriptor actionDescriptor, object actionReturnValue)
        {
            container.BuildUp(actionReturnValue);
            return base.CreateActionResult(controllerContext, actionDescriptor, actionReturnValue);
        }

        private void BuildUp(IEnumerable<object> targets)
        {
            foreach (var target in targets){
                container.BuildUp(target);
            }
        }
    }
}