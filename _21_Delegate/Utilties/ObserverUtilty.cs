using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Delegate.Utilties;

public class ObserverUtilty
{
    public readonly List<IObserver> observers= new List<IObserver>();

    public void AddObserver(IObserver observer) => observers.Add(observer);

    public void RemoveObserver(IObserver observer) => observers.Remove(observer);

    public void Action()
    {
        foreach (var observer in observers)
        {
            observer.Action();
        }
    }
}
