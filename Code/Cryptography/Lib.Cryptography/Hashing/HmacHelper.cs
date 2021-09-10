using System.Security.Cryptography;
using System.Text;

namespace Lib.Cryptography.Hashing
{
    public static class HmacHelper
    {
        

        private static byte[] ComputeHmac(this HashAlgorithmEnum algorithm, byte[] key, byte[] input)
        {
            KeyedHashAlgorithm hmacAlgo = new HMACMD5();
            switch (algorithm)
            {
                case HashAlgorithmEnum.Md5: hmacAlgo = new HMACMD5(key);
                    break;
                case HashAlgorithmEnum.Sha1: hmacAlgo = new HMACSHA1(key);
                    break;
                case HashAlgorithmEnum.Sha2256: hmacAlgo = new HMACSHA256(key);
                    break;
                case HashAlgorithmEnum.Sha2384: hmacAlgo = new HMACSHA384(key);
                    break;
                case HashAlgorithmEnum.Sha2512: hmacAlgo = new HMACSHA512(key);
                    break;
            }

            return hmacAlgo.ComputeHash(input);
        }
        
        public static byte[] ComputeMd5Hmac(this byte[] input, byte[] key)
        {
            return HashAlgorithmEnum.Md5.ComputeHmac(key, input);
        }
        
        public static byte[] ComputeMd5Hmac(this string input, byte[] key)
        {
            return Encoding.UTF8.GetBytes(input).ComputeMd5Hmac(key);
        }
        
        public static byte[] ComputeSha1Hmac(this byte[] input, byte[] key)
        {
            return HashAlgorithmEnum.Sha1.ComputeHmac(key, input);
        }
        
        public static byte[] ComputeSha1Hmac(this string input, byte[] key)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha1Hmac(key);
        }
        
        public static byte[] ComputeSha2_256Hmac(this byte[] input, byte[] key)
        {
            return HashAlgorithmEnum.Sha2256.ComputeHmac(key, input);
        }
        
        public static byte[] ComputeSha2_256Hmac(this string input, byte[] key)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_256Hmac(key);
        }
        
        public static byte[] ComputeSha2_384Hmac(this byte[] input, byte[] key)
        {
            return HashAlgorithmEnum.Sha2384.ComputeHmac(key, input);
        }
        
        public static byte[] ComputeSha2_384Hmac(this string input, byte[] key)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_384Hmac(key);
        }
        
        public static byte[] ComputeSha2_512Hmac(this byte[] input, byte[] key)
        {
            return HashAlgorithmEnum.Sha2512.ComputeHmac(key, input);
        }
        
        public static byte[] ComputeSha2_512Hmac(this string input, byte[] key)
        {
            return Encoding.UTF8.GetBytes(input).ComputeSha2_512Hmac(key);
        }
        
    }
}