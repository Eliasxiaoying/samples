using _10_FileProvider.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace _10_FileProvider.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;

    private readonly IFileProvider fileProvider;

    public HomeController(ILogger<HomeController> logger, IFileProvider fileProvider)
    {
        this.logger = logger;
        this.fileProvider = fileProvider;
    }

    public IActionResult Index()
    {
        var directoryContents = fileProvider.GetDirectoryContents(string.Empty);
        return View(directoryContents);
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