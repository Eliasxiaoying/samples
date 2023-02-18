using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _28_CoreClr;

/// <summary>
/// 标准Dispose的写法
/// </summary>
public class StandardDisposeDemo : IDisposable
{
    private string? _managedResource = "托管资源";

    private string? _unmanagedResource = "非托管资源";

    private bool IsDisposed = false;

    public void Dispose()
    {
        this.Dispose(true);
        GC.SuppressFinalize(this);//通知垃圾回收机制不再调用终结器（析构器）
    }

    public void Close()
    {
        this.Dispose();
    }

    /// <summary>
    /// 防备忘记显式调用Dispose方法
    /// </summary>
    ~StandardDisposeDemo()
    {
        this.Dispose(false);
    }

    /// <summary>
    /// 非密封类修饰用protected virtual
    /// 密封类修饰用private
    /// </summary>
    /// <param name="disposing"></param>
    protected virtual void Dispose(bool disposing)
    {
        if (IsDisposed)
        {
            return;
        }

        if (disposing)
        {
            if (this._managedResource != null)
            {
                this._managedResource = null;
            }
        }

        if (this._unmanagedResource != null)
        {
            this._unmanagedResource = null;
        }

        this.IsDisposed = true;
    }

    /// <summary>
    /// 获取资源
    /// </summary>
    /// <exception cref="ObjectDisposedException"></exception>
    public void GetResource()
    {
        if (IsDisposed)
        {
            throw new ObjectDisposedException(nameof(_managedResource), $"{nameof(_managedResource)} Has already Disposed");
        }
        Console.WriteLine("获取资源成功");
    }
}
