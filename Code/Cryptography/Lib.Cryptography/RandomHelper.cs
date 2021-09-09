using System;
using System.Security.Cryptography;

namespace Lib.Cryptography
{
    public static class Random
    {
        /// <summary>
        /// Generates Random Numbers 
        /// </summary>
        /// <param name="numberOfRandom">Number of random numbers required</param>
        /// <returns>byte array of random numbers</returns>
        /// <exception cref="ArgumentException"></exception>
        public static byte[] GetRandomNumber(this int numberOfRandom)
        {
            if (numberOfRandom <= 0)
            {
                throw new ArgumentException($"Length should be a positive number {numberOfRandom}");
            }

            using (var randomNumberGenerator = new RNGCryptoServiceProvider())
            {
                var output = new byte[numberOfRandom];
                randomNumberGenerator.GetBytes(output);
                return output;
            }
        }
    }
}