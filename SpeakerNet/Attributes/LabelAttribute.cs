using System.ComponentModel;
using SpeakerNet.Properties;

namespace SpeakerNet.Attributes
{
    public class LabelAttribute : DisplayNameAttribute
    {
        public LabelAttribute(string resourceName)
            : base(SpeakertNetStrings.ResourceManager.GetString(resourceName, SpeakertNetStrings.Culture)) {}
    }
}