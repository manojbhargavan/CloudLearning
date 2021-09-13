namespace Lib.Cryptography.Key
{
    public static class KeyHelper
    {
        public static byte[] GenerateKey(this int length)
        {
            return length.GetRandomNumber();
        }
    }
}