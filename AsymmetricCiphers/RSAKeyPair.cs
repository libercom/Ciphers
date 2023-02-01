using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class RSAKeyPair
    {
        public RSAKey PublicKey { get; set; }
        public RSAKey PrivateKey { get; set; }

        public RSAKeyPair(BigInteger e, BigInteger d, BigInteger m)
        {
            PublicKey = new RSAKey { Exponent = e, Modulus = m };
            PrivateKey = new RSAKey { Exponent = d, Modulus = m };
        }
    }
}
