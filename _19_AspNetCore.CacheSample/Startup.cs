using _19_AspNetCore.CacheSample.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace _19_AspNetCore.CacheSample;

public class Startup
{
	public Startup(IConfiguration configuration)
	{
		Configuration = configuration;
	}

	public IConfiguration Configuration { get; }

	public void ConfigureServices(IServiceCollection services)
	{
		// 添加自定义的内存缓存
		services.AddMyMemoryCache();

		// 添加内存缓存 并针对配置 效果同上
		//services.AddMemoryCache(options =>
		//{
		//	// 超过最大大小时压缩缓存的量。
		//	options.CompactionPercentage = 0;

		//	// 缓存的大小限制
		//	options.SizeLimit = 1024;

		//	// 过期扫描频率
		//	options.ExpirationScanFrequency = TimeSpan.FromHours(1);
		//});

		services.AddRedisCache("redisServer");

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
		}
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
