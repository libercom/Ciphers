using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalCiphers
{
    public class CaesarCipher : ICipher
    {
        private readonly int m_Shift;

        public CaesarCipher(int shift)
        {
            m_Shift = shift;
        }

        public string Encrypt(string message)
        {
            string encryptedMessage = "";
            string lowerCaseMessage = message.ToLower();

            foreach (var ch in lowerCaseMessage)
            {
                if (ch != ' ')
                {
                    encryptedMessage += (char) ((ch - 97 + m_Shift) % 26 + 97);
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

            foreach (var ch in lowerCaseMessage)
            {
                if (ch != ' ')
                {
                    decryptedMessage += (char) ((ch - 97 + 26 - m_Shift) % 26 + 97);
                }
                else
                {
                    decryptedMessage += ' ';
                }
            }

            return decryptedMessage;
        }
    }
}
