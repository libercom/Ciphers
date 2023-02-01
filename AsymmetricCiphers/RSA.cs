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
        private readonly RSAKeyPair _rsaKeyPair;
        private readonly RSAEncryptorDecryptor _rsaEncryptorDecryptor;

        public RSA()
        {
            var rsaKeyGenerator = new RSAKeyGenerator();

            _rsaKeyPair = rsaKeyGenerator.GenerateKeyPair();
            _rsaEncryptorDecryptor = new RSAEncryptorDecryptor();
        }

        public string Decrypt(string message)
        {
            return _rsaEncryptorDecryptor.Decrypt(message, _rsaKeyPair.PrivateKey);
        }

        public string Encrypt(string message)
        {
            return _rsaEncryptorDecryptor.Encrypt(message, _rsaKeyPair.PublicKey);
        }
    }
}
