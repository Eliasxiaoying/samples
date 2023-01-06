using _08_Options.Configs;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace _08_Options;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => { options.EnableEndpointRouting = false; });
        services.AddOptions();
        services.Configure<MyOptions>(Configuration.GetSection("MyOptions"));
        services.Configure<SubOption>("config1", Configuration.GetSection("MyOptions:SubOption1"));
        services.Configure<SubOption>("config2", Configuration.GetSection("MyOptions:SubOption2"));

        services.Configure<RedisOptions>(config =>
        {
            config.Host = "127.0.0.1";
            config.Port = 6273;
            config.UserName = "elias";
            config.Password = "123456";
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMvc(routeBuilder =>
        {
            routeBuilder.MapRoute("default", "{controller}/{action}/{id?}");
        });

        app.Run(async context =>
        {
            await context.Response.WriteAsync($"{DateTime.Now}");
        });
    }
}