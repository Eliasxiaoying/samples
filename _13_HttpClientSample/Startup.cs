using _13_HttpClientSample.MessageHandlers;
using _13_HttpClientSample.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Polly;
using System;

namespace _13_HttpClientSample;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddRefitClient<IBookService>()
            .ConfigureHttpClient(client => client.BaseAddress = new Uri("http://localhost:5000/"))
            .AddHttpMessageHandler<ValidateHeaderHandler>()
            // ÖØÊÔÅäÖÃ
            .AddTransientHttpErrorPolicy(policy => policy.RetryAsync(3))
            // ÈÛ¶ÏÅäÖÃ
            .AddTransientHttpErrorPolicy(policy => policy.CircuitBreakerAsync(5, TimeSpan.FromSeconds(30)));

        //services.AddSingleton<IBookService, BookService>();
        services.AddControllersWithViews();
    }
        
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
        });
    }
}