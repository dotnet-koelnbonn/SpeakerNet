using System;
using System.Web.Mvc;
using SpeakerNet.Data;

namespace SpeakerNet.Infrastructure.Mvc
{
    public class DatabaseContextActionInvoker : ControllerActionInvoker
    {
        readonly IDatabaseContext databaseContext;

        public DatabaseContextActionInvoker()
        {
            databaseContext = (IDatabaseContext) DependencyResolver.Current.GetService(typeof (IDatabaseContext));
        }

        protected override ActionResult InvokeActionMethod(ControllerContext controllerContext, ActionDescriptor actionDescriptor,
                                                           System.Collections.Generic.IDictionary<string, object> parameters)
        {
            using (databaseContext) {
                return base.InvokeActionMethod(controllerContext, actionDescriptor, parameters);
            }
        }
    }
}