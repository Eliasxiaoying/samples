using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace _09_Logger;

public class Program
{
    public static void Main(string[] args)
    {
        ILoggerFactory loggerFactory = new LoggerFactory();
        loggerFactory.AddNLog();

        var logger = loggerFactory.CreateLogger<Program>();
        
        logger.LogError(new EventId(1), null, "{Age}", new { Age = 22 });
    }
}