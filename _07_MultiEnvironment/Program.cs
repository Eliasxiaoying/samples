using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _07_MultiEnvironment;

// Environment

public class Program
{
    public static void Main(string[] args)
    {
        var hostBuilder = CreateHostBuilder(args);

        hostBuilder
            .Build()
            .Run();
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        var builder = Host.CreateDefaultBuilder(args);
        return builder.ConfigureWebHostDefaults(webBuilder =>
        {
            webBuilder.UseStartup<Startup>();
        });
    }
}