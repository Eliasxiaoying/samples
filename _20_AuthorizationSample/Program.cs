using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace AuthorizationSample;

public class Program
{
	public static void Main(string[] args)
	{
		CreateWebHostBuilder(args).Build().Run();
	}

	public static IWebHostBuilder CreateWebHostBuilder(string[] args)
	{
		var builder = WebHost.CreateDefaultBuilder(args);
		return builder.UseStartup<Startup>();
	}
}