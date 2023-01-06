using System;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace _19_AspNetCore.CacheSample.Extensions
{
	public static class MyMemoryCacheExtensions
	{
		/// <summary>
		/// 向系统中加入自定的内存缓存
		/// </summary>
		/// <param name="services"></param>
		/// <returns></returns>
		public static IServiceCollection AddMyMemoryCache(this IServiceCollection services)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}

			services.AddOptions();
			services.TryAdd(ServiceDescriptor.Singleton<IMemoryCache, MyMemoryCache>());
			return services;
		}
	}
}