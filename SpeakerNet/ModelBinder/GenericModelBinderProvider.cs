using System;
using System.Web.Mvc;

namespace SpeakerNet.ModelBinder
{
    public class GenericModelBinderProvider : IModelBinderProvider
    {
        public IModelBinder GetBinder(Type modelType)
        {
            if (!modelType.IsClass)
                return null;
            var genericType = typeof (IModelBinder<>).MakeGenericType(modelType);
            return (IModelBinder) DependencyResolver.Current.GetService(genericType);
        }
    }
}