using _21_Delegate.Utilties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _21_Delegate.Entity;

public class Cat : IObserver
{
    #region 面向过程
    public void Meow()
    {
        Console.WriteLine("猫叫");
    }
    #endregion

    #region 委托实现
    public Action MeowAction;

    public void MeowDelegate()
    {
        this.Meow();
        this.MeowAction?.Invoke();
    }
    #endregion

    #region 事件实现
    public event Action MeowEvent;

    public void MeowEventAction()
    {
        this.Meow();
        this.MeowEvent?.Invoke();
    }
    #endregion

    #region 面向对象
    private readonly ObserverUtilty observers = new ObserverUtilty();

    public void AddObserver(IObserver observer) => this.observers.AddObserver(observer);

    public void RemoveObserver(IObserver observer) => observers.RemoveObserver(observer);

    public void Action()
    {
        this.Meow();
        observers.Action();
    }
    #endregion
}
