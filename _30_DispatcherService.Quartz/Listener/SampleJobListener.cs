using System.Threading.Channels;
using Microsoft.Extensions.Logging;
using Quartz;

namespace _30_DispatcherService.Quartz.Listener;

public class SampleJobListener : IJobListener
{
    public string Name => "SampleJobListener";

    public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobToBeExecuted)), default(CancellationToken));
    }

    public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobExecutionVetoed)), default(CancellationToken));
    }

    public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException? jobException, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobWasExecuted)), default(CancellationToken));
    }
}