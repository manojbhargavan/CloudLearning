using System;
using Lib.Cryptography.Encryption.Symmetric;
using Lib.Cryptography.Key;
using Lib.Cryptography.Util;
using LoremNET;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Cryptography.Encryption.Symmetric
{
    public class AesHelperTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public AesHelperTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }
        
        [Theory]
        [InlineData(5, 32, 16)]
        [InlineData(15, 32, 16)]
        public void TestEncryptAndDecryptAes(int wordCount, int keyLength, int initVectorLength)
        {
            // Arrange
            string testString = Lorem.Sentence(wordCount);
            var key = keyLength.GenerateKey();
            var iv = initVectorLength.GenerateKey();

            // Act
            var encrypted = testString.AesEncryptFromBase64StringAndGetBase64String(key, iv);
            var decrypted = encrypted.AesDecryptFromBase64StringAndGetString(key, iv);
            _testOutputHelper.WriteLine($"Input String : {testString}");
            _testOutputHelper.WriteLine($"Key          : {key.ToBase64String()}");
            _testOutputHelper.WriteLine($"Init Vector  : {iv.ToBase64String()}");
            _testOutputHelper.WriteLine($"Encrypted    : {encrypted}");
            _testOutputHelper.WriteLine($"Decrypted    : {decrypted}");

            // Assert
            Assert.Equal(testString, decrypted);
        }
    }
}