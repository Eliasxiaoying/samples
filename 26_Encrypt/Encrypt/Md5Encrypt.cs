using System.Security.Cryptography;
using System.Text;

namespace _26_Encrypt.Encrypt
{
    public class Md5Encrypt
    {
        /// <summary>
        /// 加密字符
        /// </summary>
        /// <param name="source"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        /// <exception cref="InvalidCastException"></exception>
        public static string Encrypt(string source, int length = 32)
        {
            if (string.IsNullOrEmpty(source)) return string.Empty;

            HashAlgorithm provider = (HashAlgorithm?)CryptoConfig.CreateFromName("MD5") ?? throw new InvalidCastException();
            var bytes = Encoding.UTF8.GetBytes(source);
            var hashValue = provider.ComputeHash(bytes);
            var stringBuilder = new StringBuilder();

            switch (length)
            {
                case 16:
                    for (int i = 4; i < 12; i++)
                    {
                        stringBuilder.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                case 32:
                    for (int i = 0; i < 16; i++)
                    {
                        stringBuilder.Append(hashValue[i].ToString("x2"));
                    }
                    break;
                default:
                    foreach (var t in hashValue)
                    {
                        stringBuilder.Append(t.ToString("x2"));
                    }
                    break;
            }
            return stringBuilder.ToString();
        }

        /// <summary>
        /// 文件摘要
        /// </summary>
        /// <returns></returns>
        public static string Digest(string filePath)
        {
            using var fileStream = new FileStream(filePath, FileMode.Open);
            var md5 = MD5.Create("MD5");
            if (md5 == null) throw new InvalidOperationException();

            var hashValue = md5.ComputeHash(fileStream);
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < hashValue.Length; i++)
            {
                stringBuilder.Append(hashValue[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}
