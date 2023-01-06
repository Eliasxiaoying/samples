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
		// ����Զ�����ڴ滺��
		services.AddMyMemoryCache();

		// ����ڴ滺�� ��������� Ч��ͬ��
		//services.AddMemoryCache(options =>
		//{
		//	// ��������Сʱѹ�����������
		//	options.CompactionPercentage = 0;

		//	// ����Ĵ�С����
		//	options.SizeLimit = 1024;

		//	// ����ɨ��Ƶ��
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
