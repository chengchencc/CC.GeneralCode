using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlackMamba.Framework.Core.Security
{
    public class RSASignature
    {
        public static string Encrypt(string publickeyXml, string content)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] cipherbytes;
                rsa.FromXmlString(publickeyXml);
                cipherbytes = rsa.Encrypt(Encoding.UTF8.GetBytes(content), false);
                return Convert.ToBase64String(cipherbytes);
            }
        }

        public static string Decrypt(string privateKeyXml, string content)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] cipherbytes;
                rsa.FromXmlString(privateKeyXml);
                cipherbytes = rsa.Decrypt(Convert.FromBase64String(content), false);
                return Encoding.UTF8.GetString(cipherbytes);
            }
        }
    }
}
