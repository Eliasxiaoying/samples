using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace _30_DispatcherService.Quartz.Listener;

internal class SampleSchedulerListener : ISchedulerListener
{
    public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobScheduled)));
    }

    public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobUnscheduled)));
    }

    public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerFinalized)));
    }

    public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerPaused)));
    }

    public Task TriggersPaused(string? triggerGroup, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggersPaused)));
    }

    public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerResumed)));
    }

    public Task TriggersResumed(string? triggerGroup, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggersResumed)));
    }

    public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobAdded)));
    }

    public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobDeleted)));
    }

    public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobPaused)));
    }

    public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobInterrupted)));
    }

    public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobsPaused)));
    }

    public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobResumed)));
    }

    public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(JobsResumed)));
    }

    public Task SchedulerError(string msg, SchedulerException cause,
        CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerError)));
    }

    public Task SchedulerInStandbyMode(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerInStandbyMode)));
    }

    public Task SchedulerStarted(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerStarted)));
    }

    public Task SchedulerStarting(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerStarting)));
    }

    public Task SchedulerShutdown(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerShutdown)));
    }

    public Task SchedulerShuttingdown(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulerShuttingdown)));
    }

    public Task SchedulingDataCleared(CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(SchedulingDataCleared)));
    }
}