using _11_StateSamples.Extensions;
using _11_StateSamples.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace _11_StateSamples.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    private ISession Session => _httpContextAccessor.HttpContext.Session;

    public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger;
        _httpContextAccessor = httpContextAccessor;
    }

    public IActionResult Index()
    {
        Session.Set("elias", new Person("Elias", 22));
        _logger.LogError("Error");
        return RedirectToAction(nameof(Person));
    }

    public IActionResult Person()
    {
        var str = Session.GetString("elias");
        return Content(str);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public record Person(string Name, ushort Age)
{
    public string Name { get; } = Name;
    public ushort Age { get; } = Age;
}