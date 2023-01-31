using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalCiphers
{
    public class VigenereCipher : ICipher
    {
        private readonly string m_Key;

        public VigenereCipher(string key)
        {
            m_Key = key;
        }

        public string Encrypt(string message)
        {
            string encryptedMessage = "";
            string lowerCaseMessage = message.ToLower();
            string key = GenerateKey(message, m_Key);

            for (int i = 0; i < lowerCaseMessage.Length; i++)
            {
                char ch = lowerCaseMessage[i];

                if (ch != ' ')
                {
                    encryptedMessage += (char) ((ch + key[i] - 194) % 26 + 'a');
                }
                else
                {
                    encryptedMessage += ' ';
                }
            }

            return encryptedMessage;
        }

        public string Decrypt(string message)
        {
            string decryptedMessage = "";
            string lowerCaseMessage = message.ToLower();
            string key = GenerateKey(message, m_Key);

            for (int i = 0; i < lowerCaseMessage.Length; i++)
            {
                char ch = lowerCaseMessage[i];

                if (ch != ' ')
                {
                    decryptedMessage += (char) ((ch - key[i] + 26) % 26 + 'a');
                }
                else
                {
                    decryptedMessage += ' ';
                }
            }

            return decryptedMessage;
        }

        private string GenerateKey(string message, string word)
        {
            string key = word;

            for (int i = 0; ; i++)
            {
                if (message.Length == i)
                    i = 0;

                if (key.Length == message.Length)
                    break;

                key += key[i];
            }

            return key;
        }
    }
}
