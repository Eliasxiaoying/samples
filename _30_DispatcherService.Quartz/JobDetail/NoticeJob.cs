using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;

namespace _30_DispatcherService.Quartz.JobDetail;

// 任务明细
[PersistJobDataAfterExecution] // 会将JobDataMap中的数据持久化以实现链式参数传递
[DisallowConcurrentExecution] // 不允许并发执行
public class NoticeJob : IJob
{
    // 任务执行
    public async Task Execute(IJobExecutionContext context)
    {
        await Task.Run(() =>
        {
            var jobDataMap = context.JobDetail.JobDataMap;

            var executeCount = jobDataMap.GetIntValue("ExecuteCount");

            Console.WriteLine($"第{executeCount}次执行于{DateTime.Now}");

            jobDataMap.Put("ExecuteCount", executeCount + 1);
        });
    }
}