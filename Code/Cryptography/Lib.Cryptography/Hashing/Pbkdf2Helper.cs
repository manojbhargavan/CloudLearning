using System.Security.Cryptography;
using System.Text;

namespace Lib.Cryptography.Hashing
{
    // Password Based Key Derivation Function
    public static class Pbkdf2Helper
    {
        public static byte[] HashUsingPbkdf2(this byte[] toBeHashed, byte[] salt, int numberOfIterations)
        {
            var pbkdf = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfIterations);
            return pbkdf.GetBytes(20);
        }
        
        public static byte[] HashUsingPbkdf2(this string toBeHashed, byte[] salt, int numberOfIterations)
        {
            return Encoding.UTF8.GetBytes(toBeHashed).HashUsingPbkdf2(salt, numberOfIterations);
        }
    }
}