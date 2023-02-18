using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _26_Encrypt.Encrypt;

public class DesEncrypt
{
    /// <summary>
    /// 加密得到密文
    /// </summary>
    /// <param name="source"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string Encrypt(string source)
    {
        var des = DES.Create("DES");
        if (des == null) throw new InvalidOperationException();

        var memoryStream = new MemoryStream();
        var cryptoStream = new CryptoStream(memoryStream, des.CreateEncryptor(Encoding.UTF8.GetBytes("12345678"), Encoding.UTF8.GetBytes("12345678")), CryptoStreamMode.Write);

        var writer = new StreamWriter(cryptoStream);
        writer.Write(source);
        writer.Flush();
        cryptoStream.FlushFinalBlock();

        return Convert.ToBase64String(memoryStream.GetBuffer(), 0, memoryStream.Capacity);
    }

    /// <summary>
    /// 解密密文得到原文
    /// </summary>
    /// <param name="secret"></param>
    /// <returns></returns>
    /// <exception cref="InvalidOperationException"></exception>
    public static string Decrypt(string secret)
    {
        var des = DES.Create("DES");
        if (des == null) throw new InvalidOperationException();

        var buffer = Convert.FromBase64String(secret);

        using (MemoryStream memStream = new MemoryStream())
        {
            CryptoStream crypStream = new CryptoStream(memStream, des.CreateDecryptor(Encoding.UTF8.GetBytes("12345678"), Encoding.UTF8.GetBytes("12345678")), CryptoStreamMode.Write);
            crypStream.Write(buffer, 0, buffer.Length);
            crypStream.FlushFinalBlockAsync();
            return Encoding.UTF8.GetString(memStream.ToArray());
        }

    }
}