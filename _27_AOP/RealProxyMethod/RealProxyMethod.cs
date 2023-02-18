namespace _27_AOP.RealProxyMethod;

public class RealProxyMethod
{
    public static void TestRealProxy()
    {

    }
}

public class MessageEntity
{
    public string? Message { get; set; }
}

public interface IRunnable
{
    public void Run(MessageEntity message);
}

/// <summary>
/// 必须继承自MarshalByRefObject父类，否则无法生成
/// </summary>
public class Runnable : MarshalByRefObject, IRunnable
{
    public void Run(MessageEntity message)
    {
        Console.WriteLine($"携带的信息是：{message.Message}，即将开始工作");
    }
}

public class ProxyMethodRunner<T>
{
    private T proxyTarget;

    public ProxyMethodRunner(T target) : base()
    {
        this.proxyTarget = target;
    }
    
    
}

public static class TransparentProxy
{

}