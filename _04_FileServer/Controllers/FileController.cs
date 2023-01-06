using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System.IO;

namespace _04_FileServer.Controllers;

public class FileController : Controller
{
    // 通过访问控制器的方式获取文件 可以设置权限控制等
    public IActionResult GetFile(string name)
    {
        var file = Path.Combine(Directory.GetCurrentDirectory(), "Files", name);

        // 返回物理文件 
        return new PhysicalFileResult(file, MediaTypeHeaderValue.Parse("text/plain"));
    }
}