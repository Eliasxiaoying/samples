using System.Diagnostics;
using System.Security.Claims;
using AuthorizationSample.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationSample.Controllers;

public class HomeController : Controller
{
	public IActionResult Index()
	{
		return View();
	}

	public IActionResult About()
	{
		ViewData["Message"] = "Your application description page.";

		return View();
	}

	public IActionResult Login()
	{


		return View();
	}

	[HttpPost]
	public IActionResult Login(UserViewModel userInfo)
	{
		if (userInfo.UserName == "Elias" && userInfo.Password == "123456")
		{
			var userNameClaim = new Claim(ClaimTypes.Name, "Elias");

			var identity = new ClaimsIdentity("用户名");
			identity.AddClaim(userNameClaim);

			var principal = new ClaimsPrincipal(identity);

			return SignIn(principal, CookieAuthenticationDefaults.AuthenticationScheme);
		}

		return RedirectToAction(nameof(Error));
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