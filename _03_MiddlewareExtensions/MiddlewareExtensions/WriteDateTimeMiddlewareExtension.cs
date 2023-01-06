using _03_MiddlewareExtensions.Middlewares;
using Microsoft.AspNetCore.Builder;

namespace _03_MiddlewareExtensions.MiddlewareExtensions;

public static class WriteDateTimeMiddlewareExtension
{
    public static IApplicationBuilder UseWriteDateTime(this IApplicationBuilder app)
    {
        return app.UseMiddleware<WriteDateTimeMiddleware>();
    }
}