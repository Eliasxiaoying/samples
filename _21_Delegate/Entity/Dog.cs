using _21_Delegate.Utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Delegate.Entity;

public class Dog : IObserver
{
    public void Action()
    {
        this.Bark();
    }

    public void Bark()
    {
        Console.WriteLine("狗吠");
    }
}
