using FluentAssertions;
using TGV.Framework.Core.Helper;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class ExtensionsTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("     ")]
        public void Extensions_Validar_IsNullOrEmptyOrWhiteSpace_True(string valor)
        {
            var result = valor.IsNullOrEmptyOrWhiteSpace();
            result.Should().BeTrue();
        }

        [Fact]
        public void Extensions_Validar_IsNullOrEmptyOrWhiteSpace_False()
        {
            var result = "thiago".IsNullOrEmptyOrWhiteSpace();
            result.Should().BeFalse();
        }
    }
}
