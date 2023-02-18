using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace _30_DispatcherService.Quartz.Listener;

public class SampleTriggerListener : ITriggerListener
{
    public string Name => "SampleTriggerListener";

    public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerFired)), default(CancellationToken));
    }

    public Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        Task.Factory.StartNew(() => Console.WriteLine(nameof(VetoJobExecution)), default(CancellationToken));
        return Task.FromResult(false);
    }

    public Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerMisfired)), default(CancellationToken));
    }

    public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = new CancellationToken())
    {
        return Task.Factory.StartNew(() => Console.WriteLine(nameof(TriggerComplete)), default(CancellationToken));
    }
}