using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto.Digests;

namespace Lib.Cryptography.Hashing
{
    public static class HashingHelper
    {

        private static byte[] ComputeHash(this HashAlgorithmEnum hashHashAlgo, byte[] input)
        {
            HashAlgorithm hashAlgorithm = null;
            switch (hashHashAlgo)
            {
                case HashAlgorithmEnum.Md5: hashAlgorithm = MD5.Create(); break;
                case HashAlgorithmEnum.Sha1: hashAlgorithm = SHA1.Create(); break;
                case HashAlgorithmEnum.Sha2256: hashAlgorithm = SHA256.Create(); break; 
                case HashAlgorithmEnum.Sha2384: hashAlgorithm = SHA384.Create(); break;
                case HashAlgorithmEnum.Sha2512: hashAlgorithm = SHA512.Create(); break;
            }

            return hashAlgorithm?.ComputeHash(input);
        }
        
        public static byte[] ComputeMd5Hash(this byte[] input)
        {
            return HashAlgorithmEnum.Md5.ComputeHash(input);
        }
        
        public static byte[] ComputeMd5Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeMd5Hash();
        }
        
        public static byte[] ComputeSha1Hash(this byte[] input)
        {
            return HashAlgorithmEnum.Sha1.ComputeHash(input);
        }
        
        public static byte[] ComputeSha1Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha1Hash();
        }
        
        public static byte[] ComputeSha2_256Hash(this byte[] input)
        {
            return HashAlgorithmEnum.Sha2256.ComputeHash(input);
        }
        
        public static byte[] ComputeSha2_256Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_256Hash();
        }
        
        public static byte[] ComputeSha2_384Hash(this byte[] input)
        {
            return HashAlgorithmEnum.Sha2384.ComputeHash(input);
        }
        
        public static byte[] ComputeSha2_384Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_384Hash();
        }
        
        public static byte[] ComputeSha2_512Hash(this byte[] input)
        {
            return HashAlgorithmEnum.Sha2512.ComputeHash(input);
        }
        
        public static byte[] ComputeSha2_512Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_512Hash();
        }
        
        private static byte[] ComputeSha3Hash(this byte[] input, int bitLength)
        {
            var hashAlgo = new Sha3Digest(bitLength);
            hashAlgo.BlockUpdate(input, 0, input.Length);
            var output = new byte[bitLength / 8];
            hashAlgo.DoFinal(output, 0);
            return output;
        }
        
        public static byte[] ComputeSha3_256Hash(this byte[] input)
        {
            return input.ComputeSha3Hash(256);
        }
        
        public static byte[] ComputeSha3_256Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha3_256Hash();
        }
        
        public static byte[] ComputeSha3_384Hash(this byte[] input)
        {
            return input.ComputeSha3Hash(384);
        }
        
        public static byte[] ComputeSha3_384Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha3_384Hash();
        }
        
        public static byte[] ComputeSha3_512Hash(this byte[] input)
        {
            return input.ComputeSha3Hash(512);
        }
        
        public static byte[] ComputeSha3_512Hash(this string input)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha3_512Hash();
        }
    }
}