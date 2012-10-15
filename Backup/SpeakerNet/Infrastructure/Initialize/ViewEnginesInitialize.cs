using System;
using System.Web.Mvc;
using Aperea.Infrastructure.Bootstrap;
using SpeakerNet.Web;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class ViewEnginesInitialize :BootstrapItem
    {
        public override void Execute()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}