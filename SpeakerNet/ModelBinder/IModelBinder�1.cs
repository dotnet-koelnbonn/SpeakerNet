using System.Web.Mvc;

namespace SpeakerNet.ModelBinder
{
    public interface IModelBinder<T> : IModelBinder where T : class {}
}