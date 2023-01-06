using _21_Delegate.Entity;
using _21_Delegate.Utilties;

namespace _21_Delegate;

public class Program
{
    public static void Main(string[] args)
    {
        {
            Console.WriteLine("*************面向过程**************");
            Cat cat = new Cat();
            Dog dog = new Dog();
            Mouse mouse = new Mouse();

            cat.Meow();
            dog.Bark();
            mouse.Hide();
        }

        {
            Console.WriteLine("*************委托实现**************");
            Cat cat = new Cat();
            Dog dog = new Dog();
            Mouse mouse = new Mouse();

            cat.MeowAction += dog.Bark;
            cat.MeowAction += mouse.Hide;

            cat.MeowDelegate();
        }

        {
            Console.WriteLine("*************面向对象**************");
            Cat cat = new Cat();
            Dog dog = new Dog();
            Mouse mouse = new Mouse();

            cat.AddObserver(dog);
            cat.AddObserver(mouse);

            cat.Action();
        }

        {
            Console.WriteLine("*************事件实现**************");
            Cat cat = new Cat();
            Dog dog = new Dog();
            Mouse mouse = new Mouse();

            cat.MeowEvent += dog.Bark;
            cat.MeowEvent += mouse.Hide;

            cat.MeowEventAction();
        }
    }
}