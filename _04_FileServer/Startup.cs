using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace _04_FileServer;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(option => { option.EnableEndpointRouting = false; });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        // ʹ�þ�̬�ļ�
        // �����ʾ�̬�ļ����Ҵ����ϴ��ڶ�Ӧ���ļ�ʱ��ֱ�ӷ����ļ�
        app.UseStaticFiles();

        // ʹ��Ŀ¼���
        // �������ļ�ʱ����Ŀ¼�ķ�ʽչʾ���û� �������û����ѡ��Ҫ���ʵ��ļ�
        app.UseDirectoryBrowser();

        // ʹ��Ĭ���ļ�
        // ������վ��ĸ�Ŀ¼ʱ���Զ���ת��Ĭ�ϵ��ļ���
        app.UseDefaultFiles();

        // ʹ���ļ�ϵͳ �൱��������������һ��
        app.UseFileServer(new FileServerOptions
        {
            FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Files")),
            RequestPath = "/files",
        });

        // ʹ��Ĭ��·�ɷ����ļ�
        app.UseMvcWithDefaultRoute();

        app.Run(async context => { await context.Response.WriteAsync("Hello World!"); });
    }
}