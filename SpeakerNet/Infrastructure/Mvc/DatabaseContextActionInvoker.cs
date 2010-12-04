using System;
using System.Web.Mvc;
using SpeakerNet.Data;

namespace SpeakerNet.Infrastructure.Mvc
{
    public class DatabaseContextActionInvoker : IActionInvoker
    {
        private readonly IDatabaseContext databaseContext;
        private readonly IActionInvoker actionInvoker;

        public DatabaseContextActionInvoker(IDatabaseContext databaseContext, IActionInvoker actionInvoker)
        {
            this.databaseContext = databaseContext;
            this.actionInvoker = actionInvoker;
        }

        public bool InvokeAction(ControllerContext controllerContext, string actionName)
        {
            using (databaseContext){
               return actionInvoker.InvokeAction(controllerContext, actionName);
            }
        }
    }
}