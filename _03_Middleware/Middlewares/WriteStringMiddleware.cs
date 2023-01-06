using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace _03_Middleware.Middlewares;

public class WriteStringMiddleware
{
    public Task WriteString(HttpContext httpContext, Func<Task> next)
    {
        httpContext.Response.WriteAsync("Middleware 1\n");

        return next();
    }
}