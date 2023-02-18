using _26_Encrypt.Encrypt;

namespace _26_Encrypt;

public class Program
{
    public static void Main(string[] args)
    {
        //Console.WriteLine(Md5Encrypt.Encrypt("1"));

        var keyValuePair = RsaEncrypt.GetKeyPair();

        var secret = RsaEncrypt.Encrypt("1", keyValuePair.Key);

        Console.WriteLine($"secret: {secret}");

        var source = RsaEncrypt.Decrypt(secret, keyValuePair.Value);

        Console.WriteLine($"source: {source}");
    }
}