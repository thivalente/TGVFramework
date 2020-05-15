using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class CPFTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("xxxx")]
        [InlineData("101.101.101-10")]
        [InlineData("301x365.028-65")]
        [InlineData("10110110110")]
        public void CPF_Validar_CodigoInvalido(string codigo)
        {
            var ex = Assert.Throws<DomainException>(() => new CPF(codigo));
            Assert.Equal("O CPF está inválido", ex.Message);
        }

        [Theory]
        [InlineData("999.999.999-99")]
        [InlineData("99999999999")]
        public void CPF_Validar_CodigoValido(string codigo)
        {
            var novoCPF = new CPF(codigo);

            novoCPF.Codigo.Should().Be(codigo);
            novoCPF.ToString().Should().Be("999.999.999-99");
            novoCPF.ToSomenteNumeros().Should().Be("99999999999");
        }
    }
}
