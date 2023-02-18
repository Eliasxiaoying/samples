using _30_DispatcherService.Quartz.JobDetail;
using _30_DispatcherService.Quartz.Listener;
using _30_DispatcherService.Quartz.SampleLogProviders;
using Quartz;
using Quartz.Impl;
using Quartz.Logging;

namespace _30_DispatcherService.Quartz;

public class DispatcherManager
{
    public static async Task Init()
    {
        LogProvider.SetCurrentLogProvider(new SampleLogProvider());

        // 从调度工厂创建调度器 并启动调度
        var scheduler = await new StdSchedulerFactory().GetScheduler();
        _ = scheduler.Start();

        scheduler.ListenerManager.AddJobListener(new SampleJobListener());
        scheduler.ListenerManager.AddTriggerListener(new SampleTriggerListener());
        scheduler.ListenerManager.AddSchedulerListener(new SampleSchedulerListener());

        // 建造触发器
        var trigger = TriggerBuilder.Create()
            // 触发器名称和触发器分组
            .WithIdentity("NoticeTrigger", "NoticeTriggerGroup")
            // 触发器描述信息
            .WithDescription("This is NoticeTrigger")
            // 设置触发器的调度信息 每隔5秒触发一次，重复10次
            .WithSimpleSchedule(sc => sc.WithInterval(TimeSpan.FromSeconds(5)).WithRepeatCount(10))
            // 触发器现在开始执行
            .StartNow()
            .Build();

        // 从IJob接口的具体实现创建任务，任务详情在任务体中
        var job = JobBuilder.Create<NoticeJob>()
            .WithIdentity("NoticeJob", "NoticeJobGroup")
            .WithDescription("This is NoticeJob")
            .SetJobData(new JobDataMap()
            {
                { "ExecuteCount", 1 }
            })
            .Build();

        // 将调度器和触发器分配给调度器，任务从此时开始执行
        await scheduler.ScheduleJob(job, trigger);
    }
}