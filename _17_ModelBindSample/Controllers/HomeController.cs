using _17_ModelBindSample.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _17_ModelBindSample.ModelBinders;

namespace _17_ModelBindSample.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Test([ModelBinder(typeof(GeolocationModelBinder))] Geolocation geo)
    {
        return Content(geo.ToString());
    }

    public IActionResult About()
    {
        ViewData["Message"] = "Your application description page.";

        return View();
    }

    public IActionResult Contact()
    {
        ViewData["Message"] = "Your contact page.";

        return View();
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