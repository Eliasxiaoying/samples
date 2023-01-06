using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _09_Logger
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(builder =>
            {
                builder.AddConsole();
            });
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }
    }
}
