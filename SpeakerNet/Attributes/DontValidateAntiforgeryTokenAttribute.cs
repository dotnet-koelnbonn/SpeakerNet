using System;

namespace SpeakerNet.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class DontValidateAntiforgeryTokenAttribute : Attribute
    {
    }
}