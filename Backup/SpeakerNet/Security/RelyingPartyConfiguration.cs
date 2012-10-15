using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Aperea.Identity.Settings;
using Microsoft.IdentityModel.Claims;
using Microsoft.IdentityModel.Configuration;
using Microsoft.IdentityModel.Protocols.WSIdentity;
using SpeakerNet.Services;

namespace SpeakerNet.Security
{
    public class RelyingPartyConfiguration : Aperea.Identity.IRelyingPartyConfiguration
    {
        readonly IActionUrlBuilder urlBuilder;
        readonly IEncryptionSettings encryptionSettings;
        readonly ISigningSettings signingSettings;

        public RelyingPartyConfiguration(IActionUrlBuilder urlBuilder, IEncryptionSettings encryptionSettings,
                                         ISigningSettings signingSettings)
        {
            this.urlBuilder = urlBuilder;
            this.encryptionSettings = encryptionSettings;
            this.signingSettings = signingSettings;
        }

        public string IssuerUri
        {
            get { return urlBuilder.GetActionUrl("Index", "Home"); }
        }

        public X509Certificate2 EncryptionCertificate
        {
            get { return encryptionSettings.Certificate; }
        }

        public bool Encrypt
        {
            get { return encryptionSettings.Encrypt; }
        }

        public bool Sign
        {
            get { return signingSettings.Sign; }
        }

        public X509Certificate2 SigningCertificate
        {
            get { return signingSettings.Certificate; }
        }

        public IEnumerable<string> GetPassiveRequestorEndpoints()
        {
            yield return urlBuilder.GetActionUrl("Index", "Home");
        }

        public IEnumerable<DisplayClaim> GetClaimTypsRequested()
        {
            yield return new DisplayClaim(ClaimTypes.Name, "Name", "Name des Benutzers", "", false);
            yield return new DisplayClaim(ClaimTypes.Role, "EMail", "E-Mail des Benutzers", "", false);
        }

        public IEnumerable<string> GetSecurityTokenServiceEndpoints()
        {
            var section = MicrosoftIdentityModelSection.Current;
            if (section == null)
            {
                throw new ConfigurationErrorsException(
                    "missing <microsoft.identityModel/> section in the configuration file");
            }
            return from ServiceElement serviceElement in section.ServiceElements
                   select serviceElement.FederatedAuthentication
                   into authenticationElement
                   where authenticationElement != null && authenticationElement.WSFederation != null
                   select authenticationElement.WSFederation.Issuer;
        }
    }
}