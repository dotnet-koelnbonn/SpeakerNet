using System.Web.Helpers;
using Aperea.Infrastructure.Bootstrap;
using Microsoft.IdentityModel.Claims;

namespace SpeakerNet.Infrastructure.Initialize
{
    public class InitializeAntiForgeryToken  : BootstrapItem
    {
        public override void Execute()
        {
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;
        }
    }
}