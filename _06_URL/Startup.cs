using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using Microsoft.AspNetCore.Rewrite;

namespace _06_URL;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        var options = new RewriteOptions();
        options.AddRedirect("baidu/?q=(.*)", "blog/$1");
        app.UseRewriter(options);

        app.Run(async context =>
        {
            var requestPath = $"{context.Request.Scheme}://{context.Request.Host}{context.Request.Path}{context.Request.QueryString}";
            await context.Response.WriteAsync($"{DateTime.Now} => {requestPath}");
        });
    }
}