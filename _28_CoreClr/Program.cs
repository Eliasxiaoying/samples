namespace _28_CoreClr;

public class Program
{
    public static void Main(string[] args)
    {
        TestString();
    }

    public static void TestString()
    {
        string value1 = "Elias";
        string value2 = "Helios";

        // 只是将value1的内存地址赋值给了value2 因此value2和value1是一摸一样的
        // value2 = value1;
        Console.WriteLine(object.ReferenceEquals(value1, value2));

        // 因为无法判断新创建的内存空间是多大，因此会创建新的对象，会分配一块新的内存给value3
        string value3 = string.Format("Elia{0}", "s");
        Console.WriteLine($"value1:{value1}, value2:{value3}");
        Console.WriteLine(object.ReferenceEquals(value1, value3));

        // 通过编译器优化后 value4会直接等于'Helios',从声明上来说于value2一模一样
        string value4 = "Heli" + "os";
        Console.WriteLine($"value2:{value2}, value2:{value4}");
        Console.WriteLine(object.ReferenceEquals(value2, value4));

        // 虽然字面量值相等，但是因为无法判断新创建的内存大小，因此会重新创建
        string half = "He";
        string value5 = half + "lios";
        Console.WriteLine($"value2:{value2}, value5:{value5}");
        Console.WriteLine(object.ReferenceEquals(value2, value5));
    }
}