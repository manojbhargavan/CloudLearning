using Lib.Cryptography.Hashing;
using Lib.Cryptography.Key;
using Lib.Cryptography.Util;
using LoremNET;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Cryptography.Hashing
{
    public class HmacHelperTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public HmacHelperTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(10)]
        [InlineData(15)]
        [InlineData(20)]
        public void HashTest(int wordCount)
        {
            // Arrange
            string randomString = Lorem.Sentence(wordCount);

            // Act
            var key = KeyHelper.GenerateKey(256);
            var hash1Md5 = randomString.ComputeMd5Hmac(key);
            var hash2Md5 = randomString.ComputeMd5Hmac(key);
            var hash1Sha1 = randomString.ComputeSha1Hmac(key);
            var hash2Sha1 = randomString.ComputeSha1Hmac(key);
            var hash1Sha2256 = randomString.ComputeSha2_256Hmac(key);
            var hash2Sha2256 = randomString.ComputeSha2_256Hmac(key);
            var hash1Sha2384 = randomString.ComputeSha2_384Hmac(key);
            var hash2Sha2384 = randomString.ComputeSha2_384Hmac(key);
            var hash1Sha2512 = randomString.ComputeSha2_512Hmac(key);
            var hash2Sha2512 = randomString.ComputeSha2_512Hmac(key);

            _testOutputHelper.WriteLine($"Input String           : {randomString}");
            _testOutputHelper.WriteLine($"Key                    : {key.ToBase64String()}");
            _testOutputHelper.WriteLine($"MD5                    : {hash1Md5.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA1                   : {hash1Sha1.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA2 256               : {hash1Sha2256.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA2 384               : {hash1Sha2384.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA2 512               : {hash1Sha2512.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA2 512 (Base64)      : {hash1Sha2512.ToBase64String()}");
            _testOutputHelper.WriteLine($"SHA2 512 (Hexadecimal) : {hash1Sha2512.ToHexadecimalString()}");

            // Assert
            Assert.Equal(hash1Md5, hash2Md5);
            Assert.Equal(hash1Sha1, hash2Sha1);
            Assert.Equal(hash1Sha2256, hash2Sha2256);
            Assert.Equal(hash1Sha2384, hash2Sha2384);
            Assert.Equal(hash1Sha2512, hash2Sha2512);
        }
        
        [Fact]
        public void HashTest_Negative()
        {
            // Arrange
            string randomString1 = Lorem.Sentence(10);
            string randomString2 = Lorem.Sentence(10);

            // Act
            var key = KeyHelper.GenerateKey(256);
            var hash1 = randomString1.ComputeMd5Hmac(key);
            var hash2 = randomString2.ComputeMd5Hmac(key);
            _testOutputHelper.WriteLine($"{randomString1}: {hash1.ToBase64String()}");
            _testOutputHelper.WriteLine($"{randomString2}: {hash2.ToBase64String()}");

            // Assert
            Assert.NotEqual(hash1, hash2);
        }
    }
}