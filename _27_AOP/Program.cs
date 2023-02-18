using _27_AOP.DesignPattern;

namespace _27_AOP
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ProxyPattern.TestProxy();

            Console.WriteLine("--------------------------");

            DecoratorPattern.TestDecorator();
        }
    }
}