using _08_Options.Configs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace _08_Options.Controllers;

public class OptionController
{
    private readonly MyOptions myOptions;

    private readonly SubOption myOptions1;
    private readonly SubOption myOptions2;
    private readonly RedisOptions redisOptions;

    public OptionController(
        IOptions<MyOptions> myOptionsAccessor,
        IOptionsSnapshot<SubOption> optionsAccessor,
        IOptions<RedisOptions> redisOptionsAccessor)
    {
        myOptions = myOptionsAccessor.Value;
        myOptions1 = optionsAccessor.Get("config1");
        myOptions2 = optionsAccessor.Get("config2");
        redisOptions = redisOptionsAccessor.Value;
    }

    public IActionResult Index()
    {
        return new JsonResult(myOptions);
    }

    public IActionResult Option1()
    {
        return new JsonResult(myOptions1);
    }

    public IActionResult Option2()
    {
        return new JsonResult(myOptions2);
    }

    public IActionResult RedisOptions()
    {
        return new JsonResult(redisOptions);
    }
}