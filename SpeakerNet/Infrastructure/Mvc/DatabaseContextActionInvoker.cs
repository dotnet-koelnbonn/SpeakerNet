using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Aperea.Data;
using SpeakerNet.Data;

namespace SpeakerNet.Infrastructure.Mvc
{
    public class DatabaseContextActionInvoker : ControllerActionInvoker
    {
        readonly IDatabaseContext databaseContext;

        public DatabaseContextActionInvoker()
        {
            databaseContext = DependencyResolver.Current.GetService<IDatabaseContext>();
        }

        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext,
                                                           ActionDescriptor actionDescriptor,
                                                           IDictionary<string, object> parameters)
        {
            using (databaseContext) {
                return base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
        }
    }
}