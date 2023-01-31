using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class KeyPair
    {
        public int PublicKey { get; set; }
        public int PrivateKey { get; set; }

        public KeyPair(int publicKey, int privateKey)
        {
            PublicKey = publicKey;
            PrivateKey = privateKey;
        }
    }
}
