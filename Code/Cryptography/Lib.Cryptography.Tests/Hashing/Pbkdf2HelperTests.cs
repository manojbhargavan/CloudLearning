using Lib.Cryptography.Hashing;
using Lib.Cryptography.Key;
using Lib.Cryptography.Util;
using LoremNET;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Cryptography.Hashing
{
    public class Pbkdf2HelperTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public Pbkdf2HelperTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(10, 10, 10, true)]
        [InlineData(10, 100, 100, true)]
        [InlineData(10, 1000, 100, false)]
        [InlineData(10, 10000, 10000, true)]
        [InlineData(15, 20000, 300000, false)]
        [InlineData(20, 300000, 300000, true)]
        public void HashTest(int wordCount, int iterationCount1, int iterationCount2, bool hashMatch)
        {
            // Arrange
            string randomString = Lorem.Sentence(wordCount);

            // Act
            var key = KeyHelper.GenerateKey(32);
            var hashUsingPbkdf21 = randomString.HashUsingPbkdf2(key, iterationCount1);
            var hashUsingPbkdf22 = randomString.HashUsingPbkdf2(key, iterationCount2);

            // Assert
            if (hashMatch)
            {
                Assert.Equal(hashUsingPbkdf21, hashUsingPbkdf22);
                _testOutputHelper.WriteLine($"Input String           : {randomString}");
                _testOutputHelper.WriteLine($"Key                    : {key.ToBase64String()}");
                _testOutputHelper.WriteLine($"PBKDF                  : {hashUsingPbkdf21.ToBase64String()}");
                _testOutputHelper.WriteLine($"PBKDF (Hexadecimal) : {hashUsingPbkdf21.ToHexadecimalString()}");
            }
            else
            {
                Assert.NotEqual(hashUsingPbkdf21, hashUsingPbkdf22);
                _testOutputHelper.WriteLine($"Input String           : {randomString}");
                _testOutputHelper.WriteLine($"Key                    : {key.ToBase64String()}");
                _testOutputHelper.WriteLine($"PBKDF1                 : {hashUsingPbkdf21.ToBase64String()}");
                _testOutputHelper.WriteLine($"PBKDF2                 : {hashUsingPbkdf22.ToBase64String()}");
            }
        }
    }
}