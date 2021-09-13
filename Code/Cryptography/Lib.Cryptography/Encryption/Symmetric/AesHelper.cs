using System.IO;
using System.Security.Cryptography;
using System.Text;
using Lib.Cryptography.Util;

namespace Lib.Cryptography.Encryption.Symmetric
{
    public static class AesHelper
    {
        public static byte[] AesEncrypt(this byte[] input, byte[] key, byte[] initVector)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = initVector;

                using (var memData = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memData, aes.CreateEncryptor(), CryptoStreamMode.Write);
                    
                    cryptoStream.Write(input, 0, input.Length);
                    cryptoStream.FlushFinalBlock();

                    return memData.ToArray();
                }
            }
        }

        public static string AesEncryptFromBase64StringAndGetBase64String(this string input, byte[] key, byte[] initVector)
        {
            return Encoding.UTF8.GetBytes(input).AesEncrypt(key, initVector).ToBase64String();
        }

        public static byte[] AesDecrypt(this byte[] input, byte[] key, byte[] initVector)
        {
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.PKCS7;
                aes.Key = key;
                aes.IV = initVector;

                using (var memData = new MemoryStream())
                {
                    var cryptoStream = new CryptoStream(memData, aes.CreateDecryptor(), CryptoStreamMode.Write);
                    
                    cryptoStream.Write(input, 0, input.Length);
                    cryptoStream.FlushFinalBlock();

                    return memData.ToArray();
                }
                
            }
        }
        
        public static string AesDecryptFromBase64StringAndGetString(this string input, byte[] key, byte[] initVector)
        {
            return input.ToBytesFromBase64String().AesDecrypt(key, initVector).GetUtf8String();
        }
    }
}