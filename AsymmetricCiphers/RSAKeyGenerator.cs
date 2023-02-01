using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class RSAKeyGenerator
    {
        private const int p = 61;
        private const int q = 53;
        private const int e = 17;
        private const int d = 2753;

        public RSAKeyPair GenerateKeyPair()
        {
            var n = p * q;

            return new RSAKeyPair(e, d, n);
        }
    }
}
