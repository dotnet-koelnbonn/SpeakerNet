using System;
using Aperea.Infrastructure.Bootstrap;
using Aperea.Infrastructure.IoC;

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
            Bootstrapper.Start();
            AutoMapper.Mapper.AssertConfigurationIsValid();
        }
    }
}