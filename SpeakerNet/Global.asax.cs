using System;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Infrastructure.Registration;

namespace SpeakerNet
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RegisterStructureMap.Execute();
            Bootstrapper.Start()
                .FromServiceLocator()
                .Execute();
        }
    }
}