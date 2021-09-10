using System;
using Lib.Cryptography;
using Lib.Cryptography.Key;
using Lib.Cryptography.Util;
using Xunit;
using Xunit.Abstractions;

namespace Tests.Cryptography
{
    public class RandomTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public RandomTests(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [InlineData(10, false)]
        [InlineData(40, false)]
        [InlineData(0, true)]
        [InlineData(-10, true)]
        [InlineData(-1, true)]
        [InlineData(1, false)]
        public void RandomNumberReturnByteArray(int outputLength, bool exceptionExpected)
        {
            // Arrange

            if (!exceptionExpected)
            {
                // Act
                var result = outputLength.GetRandomNumber();
                _testOutputHelper.WriteLine($"Random Base64 String: {result.ToBase64String()}");

                // Assert
                Assert.Equal(outputLength, result.Length);
            }
            else
            {
                //Assert
                Assert.Throws<ArgumentException>(() =>
                {
                    // Act
                    var result = outputLength.GetRandomNumber();
                    _testOutputHelper.WriteLine($"Random Base64 String: {result.ToBase64String()}");
                });
            }
        }

    }
}