using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;

namespace _19_AspNetCore.CacheSample.Extensions
{
	public static class RedisCacheExtensions
	{
		public static IServiceCollection AddRedisCache(this IServiceCollection services, string connStrName, string instanceName = "Instance")
		{
			var config = new ConfigurationBuilder().AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json")).Build();

			return services.AddDistributedRedisCache(options =>
			{
				options.Configuration = config.GetConnectionString(connStrName);
				options.InstanceName = instanceName;
			});
		}
	}
}
