using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Interfaces
{
    public interface ICipher
    {
        string Encrypt(string message);
        string Decrypt(string message);
    }
}
