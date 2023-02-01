using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class RSAKey
    {
        public BigInteger Exponent { get; set; }
        public BigInteger Modulus { get; set; }
    }
}
