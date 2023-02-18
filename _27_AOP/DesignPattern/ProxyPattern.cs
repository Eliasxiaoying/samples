using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _27_AOP.DesignPattern;

public class ProxyPattern
{
    public static void TestProxy()
    {
        var executer = new Executer();
        executer.Execute();

        Console.WriteLine("----------------------");

        var proxyExecuter = new ProxyExecuter();
        proxyExecuter.Execute();
    }
}

public interface IExecute
{
    void Execute();
}

public class Executer : IExecute
{
    public void Execute()
    {
        Console.WriteLine("执行业务流程");
    }
}

public class ProxyExecuter : IExecute
{
    private IExecute executer = new Executer();

    public void Execute()
    {
        BeforeExecute();
        executer.Execute();
        AfterExecute();
    }

    private void BeforeExecute()
    {
        Console.WriteLine("执行前执行一些预热");
    }

    private void AfterExecute()
    {
        Console.WriteLine("执行后执行一些清理");
    }
}
