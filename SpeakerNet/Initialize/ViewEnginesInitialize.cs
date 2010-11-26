using System;
using System.Web.Mvc;
using SpeakerNet.Infrastructure.Bootstrap;
using SpeakerNet.Web;

namespace SpeakerNet.Initialize
{
    public class ViewEnginesInitialize : IBootstrapItem
    {
        public void Execute()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.AddIPhone<RazorViewEngine>();
            ViewEngines.Engines.AddIPad<RazorViewEngine>();
            ViewEngines.Engines.AddGenericMobile<RazorViewEngine>();
            ViewEngines.Engines.Add(new RazorViewEngine());
        }
    }
}