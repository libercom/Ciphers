using Shared.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassicalCiphers
{
    public class CaesarCipherWithKey : ICipher
    {
        private readonly int m_Shift;
        private readonly string m_Alphabet;
        private readonly string m_ShiftedAlphabet;

        public CaesarCipherWithKey(int shift, string key)
        {
            string lowerCaseKey = key.ToLower();
            m_Shift = shift;
            m_Alphabet = "abcdefghijklmnopqrstuvwxyz";
            m_ShiftedAlphabet = "";

            foreach (var ch in lowerCaseKey)
            {
                if (m_ShiftedAlphabet.IndexOf(ch) == -1)
                {
                    m_ShiftedAlphabet += ch;
                }
            }

            foreach (var ch in m_Alphabet)
            {
                if (m_ShiftedAlphabet.IndexOf(ch) == -1)
                {
                    m_ShiftedAlphabet += ch;
                }
            }
        }

        public string Encrypt(string message)
        {
            string encryptedMessage = "";
            string lowerCaseMessage = message.ToLower();

            foreach (var ch in lowerCaseMessage)
            {
                if (ch != ' ')
                {
                    int index = m_Alphabet.IndexOf(ch);

                    encryptedMessage += m_ShiftedAlphabet[(index + m_Shift) % 26];
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
                    int index = m_ShiftedAlphabet.IndexOf(ch);

                    decryptedMessage += m_Alphabet[(index + 26 - m_Shift) % 26];
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
