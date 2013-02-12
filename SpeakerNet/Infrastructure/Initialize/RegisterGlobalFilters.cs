using System;
using System.Web.Mvc;
using Aperea.Infrastructure.Bootstrap;
using SpeakerNet.FilterAttributes;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class RegisterGlobalFilters : BootstrapItem
    {
        public override void Execute()
        {
            Register(GlobalFilters.Filters);
        }

        void Register(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}