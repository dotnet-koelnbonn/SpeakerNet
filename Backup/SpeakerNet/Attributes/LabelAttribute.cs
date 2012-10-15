using System.ComponentModel;
using SpeakerNet.Properties;

namespace SpeakerNet.Attributes
{
    public class LabelAttribute : DisplayNameAttribute
    {
        private readonly string _resourceName;

        public LabelAttribute(string resourceName)
        {
            _resourceName = resourceName;
        }

        public override string DisplayName
        {
            get
            {
                var displayName = SpeakerNetStrings.ResourceManager.GetString(_resourceName);
                return displayName ?? @"Missing: " + _resourceName;
            }
        }
    }
}