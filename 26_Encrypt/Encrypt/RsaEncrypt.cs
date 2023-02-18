using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _26_Encrypt.Encrypt
{
    public class RsaEncrypt
    {
        public static KeyValuePair<string, string> GetKeyPair()
        {
            var rsa = RSA.Create("RSA");
            var publicKey = rsa.ToXmlString(false);
            var privateKey = rsa.ToXmlString(true);
            return new KeyValuePair<string, string>(publicKey, privateKey);
        }

        public static string Encrypt(string source, string publicKey)
        {
            var rsa = RSA.Create("RSA");
            rsa.FromXmlString(publicKey);
            var bytes = new UnicodeEncoding().GetBytes(source);
            var secret = rsa.Encrypt(bytes, RSAEncryptionPadding.OaepSHA1);

            return Convert.ToBase64String(secret);
        }

        public static string Decrypt(string secret, string privateKey)
        {
            var rsa = RSA.Create("RSA");
            rsa.FromXmlString(privateKey);

            var bytes = Convert.FromBase64String(secret);
            var source = rsa.Decrypt(bytes, RSAEncryptionPadding.OaepSHA1);

            return Convert.ToBase64String(source);
        }
    }
}
