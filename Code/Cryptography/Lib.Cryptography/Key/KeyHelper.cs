namespace Lib.Cryptography.Key
{
    public class KeyHelper
    {
        public static byte[] GenerateKey(int length)
        {
            return length.GetRandomNumber();
        }
    }
}