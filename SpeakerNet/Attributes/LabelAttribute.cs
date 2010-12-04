using System.ComponentModel;
using SpeakerNet.Properties;

namespace SpeakerNet.Attributes
{
    public class LabelAttribute : DisplayNameAttribute
    {
        public LabelAttribute(string resourceName)
            : base(GetDisplayName(resourceName))
        {
        }

        private static string GetDisplayName(string resourceName)
        {
            var displayName = SpeakertNetStrings.ResourceManager.GetString(resourceName, SpeakertNetStrings.Culture);
            return displayName ?? "Missing: " + resourceName;
        }
    }
}