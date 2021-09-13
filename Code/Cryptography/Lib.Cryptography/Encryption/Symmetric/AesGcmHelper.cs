using System.IO;
using System.Security.Cryptography;
using System.Text;
using Lib.Cryptography.Util;

namespace Lib.Cryptography.Encryption.Symmetric
{
    public static class AesGcmHelper
    {
        public static (byte[],byte[]) AesGcmEncrypt(this byte[] input, byte[] key, byte[] nonce)
        {
                byte[] tag = new byte[16];
                byte[] encryptedText = new byte[input.Length];

                using (var aes = new AesGcm(key))
                {
                    aes.Encrypt(nonce, input, encryptedText, tag);
                }

                return (encryptedText, tag);
        }

        public static (string, string) AesGcmEncryptFromBase64StringAndGetBase64String(this string input, byte[] key, byte[] initVector)
        {
            var result = Encoding.UTF8.GetBytes(input).AesGcmEncrypt(key, initVector);
            return (result.Item1.ToBase64String(), result.Item2.ToBase64String());
        }

        public static byte[] AesGcmDecrypt(this byte[] input, byte[] key, byte[] nonce, byte[] tag)
        {
            byte[] decryptedText = new byte[input.Length];

            using (var aes = new AesGcm(key))
            {
                aes.Decrypt(nonce, input, tag, decryptedText);
            }

            return decryptedText;
        }

        public static string AesGcmDecryptFromBase64StringAndGetString(this string input, byte[] key, byte[] nonce, byte[] tag)
        {
            return input.ToBytesFromBase64String().AesGcmDecrypt(key, nonce,tag).GetUtf8String();
        }
    }
}