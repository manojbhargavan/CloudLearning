using System;
using System.Text;

namespace Lib.Cryptography.Util
{
    public static class ConversionHelper
    {
        public static string ToBase64String(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }
        
        public static byte[] ToBytesFromBase64String(this string input)
        {
            return Convert.FromBase64String(input);
        }

        public static string ToHexadecimalString(this byte[] input)
        {
            return BitConverter.ToString(input);
        }
        public static string GetUtf8String(this byte[] input)
        {
            return Encoding.UTF8.GetString(input);
        }
    }
}