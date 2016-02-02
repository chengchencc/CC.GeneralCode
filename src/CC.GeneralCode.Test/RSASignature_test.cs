using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CC.GeneralCode.Test
{
    public class RSASignature_test
    {
        [Fact]
        public void key_gen_test()
        {
            using (System.Security.Cryptography.RSACryptoServiceProvider RSA = new System.Security.Cryptography.RSACryptoServiceProvider())
            {
                
                //Export the key information to an RSAParameters object.
                //Pass false to export the public key information or pass
                //true to export public and private key information.
                var privateKeyXml = RSA.ToXmlString(true);
                var publicKeyXml = RSA.ToXmlString(false);
            }
        }

    }
}
