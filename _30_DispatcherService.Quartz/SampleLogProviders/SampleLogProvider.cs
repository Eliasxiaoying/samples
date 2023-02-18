using Quartz.Logging;

namespace _30_DispatcherService.Quartz.SampleLogProviders;

public class SampleLogProvider : ILogProvider
{
    public Logger GetLogger(string name)
    {
        throw new NotImplementedException();
    }

    public IDisposable OpenNestedContext(string message)
    {
        throw new NotImplementedException();
    }

    public IDisposable OpenMappedContext(string key, object value, bool destructure = false)
    {
        throw new NotImplementedException();
    }
}