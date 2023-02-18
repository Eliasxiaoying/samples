namespace _25_Async;

public class Program
{
    static void Main(string[] args)
    {
        DoSomethingSynchronize();
    }

    static void DoSomethingSynchronize()
    {
        string something = "上班";

        Action<string> action = new Action<string>(DoSomething);
        action.Invoke(something);
        
        action.BeginInvoke(something, result =>
        {
            Console.WriteLine($"Result Finished {result}");
        }, null);
    }

    static void DoSomething(string something)
    {
        Console.WriteLine("*********Begin Do Something*****************");

        Thread.Sleep(2000);

        Console.WriteLine(something);

        Console.WriteLine("*********Something Done*****************");
    }
}