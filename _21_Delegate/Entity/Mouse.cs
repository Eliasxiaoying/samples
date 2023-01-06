using _21_Delegate.Utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Delegate.Entity;

public class Mouse : IObserver
{
    public void Action()
    {
        this.Hide();
    }

    public void Hide()
    {
        Console.WriteLine("鼠匿");
    }
}
