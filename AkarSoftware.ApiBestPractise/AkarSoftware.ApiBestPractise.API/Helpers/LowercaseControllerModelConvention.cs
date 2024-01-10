using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace AkarSoftware.ApiBestPractise.API.Helpers
{
    public class LowercaseControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            controller.ControllerName = controller.ControllerName.ToLower();
        }
    }
}
