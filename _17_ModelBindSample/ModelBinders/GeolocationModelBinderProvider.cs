using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _17_ModelBindSample.ModelBinders;

public class GeolocationModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        return new GeolocationModelBinder();
    }
}