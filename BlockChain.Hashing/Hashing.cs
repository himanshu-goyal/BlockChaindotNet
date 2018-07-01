using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain.Hashing
{
        public class Hashing
        {
            public static byte[] ComputeHashSha256(byte[] toBeHashed)
            {
                try
                {
                    using (var sha256 = SHA256.Create())
                    {
                        return sha256.ComputeHash(toBeHashed);
                    }
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
}
