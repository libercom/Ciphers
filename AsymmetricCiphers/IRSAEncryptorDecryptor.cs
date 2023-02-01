using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public interface IRSAEncryptorDecryptor
    {
        string Encrypt(string message, RSAKey publicKey);
        string Decrypt(string message, RSAKey privateKey);
    }
}
