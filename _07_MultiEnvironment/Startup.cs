using System;
using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace _07_MultiEnvironment;

public class Startup
{
	public void ConfigureServices(IServiceCollection services)
	{
		var configurationBuilder = new ConfigurationBuilder();

		var path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");

		configurationBuilder.AddJsonFile(path);

		var config = configurationBuilder.Build();

		var name = config["persons:0:name"];
		var age = config["persons:0:age"];
		var address = config["persons:0:address"];

		Console.WriteLine($"{name}-{age}-{address}");
	}

	public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
	{
		app.Run(async context => { await context.Response.WriteAsync($"{DateTime.Now}: Configure"); });
	}
}