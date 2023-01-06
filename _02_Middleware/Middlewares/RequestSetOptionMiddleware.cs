using _02_Middleware.Options;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace _02_Middleware.Middlewares;

public class RequestSetOptionMiddleware
{
    private readonly RequestDelegate next;
    private readonly IOptions<AppOptions> options;

    public RequestSetOptionMiddleware(RequestDelegate next, IOptions<AppOptions> options)
    {
        this.next = next;
        this.options = options;
    }

    public async Task Invoke(HttpContext context)
    {
        Console.WriteLine("RequestSetOptionMiddleware.InvokeAsync()");

        var options = context.Request.Query["options"];

        if (!string.IsNullOrWhiteSpace(options))
        {
            await context.Response.WriteAsync(options);
            this.options.Value.Options = options;
        }
        else
        {
            await next(context);
        }
    }
}