using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace _06_URL;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
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
