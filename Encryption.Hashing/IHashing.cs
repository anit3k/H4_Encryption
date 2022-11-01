using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Hashing
{
    public interface IHashing
    {
        string GetHashValue(string dataToHash);
    }
}
