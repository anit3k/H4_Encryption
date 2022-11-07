using Encryption.CaesarCipher.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.CaesarCipher.Factories
{
    public interface ICaesarCipherFactory
    {
        ICaesarCipherGenerator Create(); 
    }
}
