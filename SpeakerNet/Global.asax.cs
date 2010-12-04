using System;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Infrastructure.Registration;

namespace SpeakerNet
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
#if DEBUG
            HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();
#endif
            RegisterStructureMap.Execute();
            Bootstrapper.Start()
                .FromServiceLocator()
                .Execute();
        }
    }
}