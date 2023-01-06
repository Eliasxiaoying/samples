using _03_Middleware.Middlewares;
using _03_MiddlewareExtensions.ServiceExtensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _03_Middleware;

public class Startup
{
    public static WriteStringMiddleware writeStringMiddleware;

    static Startup()
    {
        writeStringMiddleware = new WriteStringMiddleware();
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddWriteDateTime();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //app.UseWriteDateTime();


        app.MapWhen(context => context.Request.Query.ContainsKey("q"), builder =>
        {
            builder.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 4\n");

                await next();
            });

            builder.Run(async context => { await context.Response.WriteAsync($"this is {DateTime.Now.ToString()}"); });
        });

        app.Map("/map1", builder =>
        {
            builder.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 2\n");

                await next();
            });

            builder.Run(async context => { await context.Response.WriteAsync($"this is {DateTime.Now.ToString()}"); });
        });

        app.Map("/map2", builder =>
        {
            builder.Use(async (context, next) =>
            {
                await context.Response.WriteAsync("Middleware 3\n");

                await next();
            });

            builder.Run(async context => { await context.Response.WriteAsync($"this is {DateTime.Now.ToString()}"); });
        });


        app.Run(async context => { await context.Response.WriteAsync($"this is {DateTime.Now.ToString()}"); });
    }
}