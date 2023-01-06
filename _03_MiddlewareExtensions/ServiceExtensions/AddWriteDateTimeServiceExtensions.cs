using _03_MiddlewareExtensions.DateTimeFormatOptions;
using _03_MiddlewareExtensions.Middlewares;
using Microsoft.Extensions.DependencyInjection;

namespace _03_MiddlewareExtensions.ServiceExtensions;

public static class AddWriteDateTimeServiceExtensions
{
    public static IServiceCollection AddWriteDateTime(this IServiceCollection services)
    {
        var option = new DateTimeFormatOption()
        {
            Format = "yyyy-MM-dd"
        };
        services.AddSingleton(option);

        return services.AddSingleton<WriteDateTimeMiddleware>();
    }
}