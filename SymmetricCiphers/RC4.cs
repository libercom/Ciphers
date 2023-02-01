using System.Text;
using Shared.Interfaces;

namespace SymmetricCiphers
{
    public class RC4 : ICipher
    {
        private readonly byte[] _s = new byte[256];
        private readonly byte[] _t = new byte[256];

        public RC4(string key)
        {
            var keyBytes = Encoding.UTF8.GetBytes(key);

            foreach (var item in keyBytes)
            {
                Console.WriteLine(item);
            }

            for (int i = 0; i < 256; i++)
            {
                _s[i] = (byte)i;
            }

            for (int i = 0; i < 256; i++)
            {
                _t[i] = keyBytes[i % 4];
            }

            int j = 0;

            for (int i = 0; i < 256; i++)
            {
                j = (j + _s[i] + _t[i]) % 256;

                byte temp = _s[i];

                _s[i] = _s[j];
                _s[j] = temp;
            }
        }

        public string Encrypt(string message)
        {
            int i = 0;
            int j = 0;

            string encryptedMessage = "";
            byte[] state = new byte[256];

            for (int x = 0; x < 256; x++)
            {
                state[x] = _s[x];
            }

            for (int x = 0; x < message.Length; x++)
            {
                i = (i + 1) % 256;
                j = (j + state[i]) % 256;

                byte temp1 = state[i];

                state[i] = state[j];
                state[j] = temp1;

                int temp2 = (state[i] + state[j]) % 256;
                int encryptedCharacter = ((int)message[x] ^ state[temp2]);

                encryptedMessage += (char)encryptedCharacter;
            }

            return encryptedMessage;
        }

        public string Decrypt(string message)
        {
            return Encrypt(message);
        }
    }
}