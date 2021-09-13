using System;
using Lib.Cryptography.Encryption.Symmetric;
using Lib.Cryptography.Key;
using Lib.Cryptography.Util;
using LoremNET;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Cryptography.Encryption.Symmetric
{
    public class AesGcmHelperTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AesGcmHelperTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(5, 32, 12)]
        [InlineData(15, 32, 12)]
        public void TestEncryptAndDecryptAes(int wordCount, int keyLength, int nonceLength)
        {
            // Arrange
            string testString = Lorem.Sentence(wordCount);
            var key = keyLength.GenerateKey();
            var nonce = nonceLength.GenerateKey();

            // Act
            var encrypted = testString.AesGcmEncryptFromBase64StringAndGetBase64String(key, nonce);
            var decrypted = encrypted.Item1.AesGcmDecryptFromBase64StringAndGetString(key, nonce, encrypted.Item2.ToBytesFromBase64String());
            _testOutputHelper.WriteLine($"Input String : {testString}");
            _testOutputHelper.WriteLine($"Key          : {key.ToBase64String()}");
            _testOutputHelper.WriteLine($"Nonce        : {nonce.ToBase64String()}");
            _testOutputHelper.WriteLine($"Encrypted    : {encrypted.Item1}");
            _testOutputHelper.WriteLine($"Tag          : {encrypted.Item2}");
            _testOutputHelper.WriteLine($"Decrypted    : {decrypted}");

            // Assert
            Assert.Equal(testString, decrypted);
        }
    }
}