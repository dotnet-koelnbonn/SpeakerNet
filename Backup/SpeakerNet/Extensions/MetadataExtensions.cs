using System;
using System.Web.Mvc;

namespace SpeakerNet.Extensions
{
    public static class MetadataExtensions
    {
        public static string GetDisplayName(this Type type, string propertyName)
        {
            return ModelMetadataProviders.Current
                .GetMetadataForProperty(() => null, type, propertyName).GetDisplayName();
        }

        public static string GetDisplayName<T>(this T instance, string propertyName)
        {
            return ModelMetadataProviders.Current
                .GetMetadataForProperty(() => instance, typeof (T), propertyName).GetDisplayName();
        }
    }
}