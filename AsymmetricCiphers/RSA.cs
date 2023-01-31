using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class RSA : ICipher
    {
        private readonly int _P = 2689;
        private readonly int _Q = 103;
        private readonly int _E = 65537;

        public string Encrypt(string message)
        {

        }

        public string Decrypt(string message)
        {

        }

        public KeyPair GenerateKeyPair()
        {
            int n = _P * _Q;
            int x = (_P - 1) * (_Q - 1);

            int d, u1, u3, v1, v3, t1, t3, q;
            int i;

            u1 = 1;
            u3 = _E;
            v1 = 0;
            v3 = x;

            i = 1;
            while (v3 != 0)
            {
                q = u3 / v3;
                t3 = u3 % v3;
                t1 = u1 + q * v1;

                u1 = v1; v1 = t1; u3 = v3; v3 = t3;
                i = -i;
            }

            if (i < 0)
            {
                d = x - u1;
            }
            else
            {
                d = u1;
            }

            return new KeyPair(n, d);
        }
    }
}
