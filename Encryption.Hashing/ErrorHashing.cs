using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encryption.Hashing
{
    public class ErrorHashing : IHashing
    {
        public string GetHashValue(string dataToHash)
        {
            return "Incorrect hashing type.";
        }
    }
}
