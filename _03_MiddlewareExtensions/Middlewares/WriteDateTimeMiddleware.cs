using _03_MiddlewareExtensions.DateTimeFormatOptions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace _03_MiddlewareExtensions.Middlewares;

public class WriteDateTimeMiddleware : IMiddleware
{
    private readonly DateTimeFormatOption options;

    public WriteDateTimeMiddleware(IOptions<DateTimeFormatOption> options)
    {
        this.options = options.Value;
    }

    public Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        context.Response.WriteAsync(DateTime.Now.ToString(options.Format));
        return next(context);
    }
}