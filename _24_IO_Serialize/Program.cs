using System.Text;

namespace _24_IO_Serialize;

public class Program
{
    public static async Task Main(string[] args)
    {
        FileTest();
        await AppendTest();
    }

    static void DirectoryTest()
    {
        string dirPath = @"D:\Abc\Def";
        if (!Directory.Exists(dirPath))
        {
            // 会递归创建所有path中包含的文件夹
            DirectoryInfo directoryInfo = Directory.CreateDirectory(dirPath);

            string movePath = @"D:\Abc\Fed";

            // 将源文件夹中的所有文件移动到指定文件夹中 原文件夹就不存在了
            Directory.Move(dirPath, movePath);

            // 删除文件 
            Directory.Delete(movePath);
        }
    }

    static void FileTest()
    {
        var dirName = @"D:\Abc\Def";
        var fileName = Path.Combine(dirName, "1.txt");
        var flag = File.Exists(fileName);
        if (!flag)
        {
            // 先创建文件夹
            Directory.CreateDirectory(dirName);

            // 创建文件流 如果不存在就新建，如果存在就直接覆盖掉
            using (FileStream fs = File.Create(fileName))
            {
                var content = "123123123123123";

                // 获取需要写入的文件的二进制
                var bytes = Encoding.Default.GetBytes(content);

                // 写入文件
                fs.Write(bytes, 0, bytes.Length);

                // 写入后清除缓冲区，文件内容才会出现在文件里
                fs.Flush();
            }
        }
        else
        {
            
        }
    }

    static async Task AppendTest()
    {
        var dirName = @"D:\Abc\Def";
        var fileName = Path.Combine(dirName, "1.txt");

        if (File.Exists(fileName))
        {
            using (var stream = File.Open(fileName, FileMode.Append))
            {
                var content = "Hello World";
                await stream.WriteAsync(Encoding.UTF8.GetBytes(content));

                stream.Flush();
            }

        }
    }
}