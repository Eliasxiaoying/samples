using System;
using System.Diagnostics;
using System.Threading.Tasks;
using _19_AspNetCore.CacheSample.Extensions;
using _19_AspNetCore.CacheSample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;

namespace _19_AspNetCore.CacheSample.Controllers;

public class HomeController : Controller
{
	private readonly ILogger<HomeController> _logger;

	private readonly IMemoryCache _memoryCache;

	private readonly IDistributedCache _distributedCache;

	public HomeController(ILogger<HomeController> logger, IMemoryCache memoryCache, IDistributedCache distributedCache)
	{
		_distributedCache = distributedCache;
		_memoryCache = memoryCache;
		_logger = logger;
	}

	public IActionResult Index()
	{
		return View();
	}

	public IActionResult Privacy()
	{
		ViewData["DateTime"] = _memoryCache.GetOrCreate("dateTime", cacheEntry =>
		{
			// 滑动过期时间
			cacheEntry.SlidingExpiration = TimeSpan.FromSeconds(3);

			// 相对于现在的绝对过期时间
			cacheEntry.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);

			return DateTime.Now;
		});
		return View();
	}

	public async Task<IActionResult> TestRedis()
	{
		ViewData["DateTime"] = await _distributedCache.GetOrCreateStringAsync("dateTime", option =>
		{
			option.SlidingExpiration = TimeSpan.FromSeconds(3);
			option.AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(10);

			return DateTime.Now.ToString();
		});

		return View(nameof(Privacy));
	}

	[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
	public IActionResult Error()
	{
		return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
	}
}
