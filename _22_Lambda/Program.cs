namespace _22_Lambda;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var enumerator = new Program().GetId().GetEnumerator()
        while (Console.ReadLine() != "")
        {
            enumerator.MoveNext();
            Console.WriteLine(enumerator.Current);
        }
    }

    public IEnumerable<long> GetId()
    {
        long start = 1;
        yield return start;
        while (true)
        {
            yield return start += 2;
        }
    }
}