using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalCiphers
{
    public class AtbashCipher : ICipher
    {
        public string Encrypt(string message)
        {
            string encryptedMessage = "";
            string lowerCaseMessage = message.ToLower();

            foreach (var ch in lowerCaseMessage)
            {
                if (ch != ' ')
                {
                    encryptedMessage += (char)('z' - ch + 'a');
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
                    decryptedMessage += (char) ('z' - ch + 'a');
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
