using _02_Middleware.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace _02_Middleware.StartupFilters;

/// <summary>
/// 请求设置Options
/// </summary>
public class RequestSetOptionStartupFilter : IStartupFilter
{
    public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
    {
        return builder =>
        {
            builder.UseMiddleware<RequestSetOptionMiddleware>();

            next(builder);
        };
    }
}