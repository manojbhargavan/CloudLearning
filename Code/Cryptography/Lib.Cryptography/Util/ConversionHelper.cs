using System;

namespace Lib.Cryptography.Util
{
    public static class ConversionHelper
    {
        public static string ToBase64String(this byte[] input)
        {
            return Convert.ToBase64String(input);
        }

        public static string ToHexadecimalString(this byte[] input)
        {
            return BitConverter.ToString(input);
        }
    }
}