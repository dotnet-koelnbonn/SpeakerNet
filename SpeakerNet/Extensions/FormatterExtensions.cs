using SpeakerNet.Services;

namespace SpeakerNet.Extensions
{
    public static class FormatterExtensions
    {
         static readonly IFormatter _formatter = new Formatter();

         public static string NamedFormat(this string format, object source)
         {
             return _formatter.Format(format, source);
         }      
    }
}