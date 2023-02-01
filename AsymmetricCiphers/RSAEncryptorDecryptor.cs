using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace AsymmetricCiphers
{
    public class RSAEncryptorDecryptor : IRSAEncryptorDecryptor
    {
        public string Encrypt(string message, RSAKey publicKey)
        {
            byte[] messageBytes = Encoding.UTF8.GetBytes(message);
            BigInteger[] encryptedBytes = Array.ConvertAll(messageBytes, b => BigInteger.ModPow(b, publicKey.Exponent, publicKey.Modulus));
            byte[] bytes = encryptedBytes.SelectMany(x => BitConverter.GetBytes((int)x)).ToArray();

            return Convert.ToBase64String(bytes);
        }

        public string Decrypt(string message, RSAKey privateKey)
        {
            byte[] bytes = Convert.FromBase64String(message);
            List<int> encryptedBytes = new List<int>();

            for (int i = 0; i < bytes.Length; i += sizeof(int))
            {
                encryptedBytes.Add(BitConverter.ToInt32(bytes, i));
            }

            BigInteger[] decryptedBytes = Array.ConvertAll(encryptedBytes.ToArray(), b => BigInteger.ModPow(b, privateKey.Exponent, privateKey.Modulus));
            byte[] decryptedMessage = decryptedBytes.SelectMany(x => x.ToByteArray()).ToArray();

            return Encoding.UTF8.GetString(decryptedMessage);
        }
    }
}
