using _30_DispatcherService.Quartz;

namespace DispatcherService;

public class Program
{
    public static async Task Main(string[] args)
    {
        await DispatcherManager.Init();

        Console.ReadKey();
    }
}