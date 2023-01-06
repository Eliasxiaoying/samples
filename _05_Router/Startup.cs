using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace _05_Router;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options => { options.EnableEndpointRouting = false; });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseMvc(routeBuilder =>
        {
            routeBuilder.MapRoute("default", "{controller}/{action}/{id:regex(^\\d{{1,200000}}$)}");
        });

        app.Run(async context => { await context.Response.WriteAsync("Hello World!"); });
    }
}