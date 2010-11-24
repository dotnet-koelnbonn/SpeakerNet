using System.Web.Mvc;
using StructureMap;

namespace SpeakerNet.Infrastructure.Registration
{
    internal class StructureMapFilterAttributeFilterProvider : FilterAttributeFilterProvider
    {
        private readonly IContainer container;

        public StructureMapFilterAttributeFilterProvider(IContainer container)
        {
            this.container = container;
        }

        protected override System.Collections.Generic.IEnumerable<FilterAttribute> GetActionAttributes(
            ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetActionAttributes(controllerContext, actionDescriptor);
            foreach (var filterAttribute in attributes){
                container.BuildUp(filterAttribute);
            }
            return attributes;
        }

        protected override System.Collections.Generic.IEnumerable<FilterAttribute> GetControllerAttributes(
            ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var attributes = base.GetControllerAttributes(controllerContext, actionDescriptor);
            foreach (var filterAttribute in attributes){
                container.BuildUp(filterAttribute);
            }
            return attributes;
        }
    }
}