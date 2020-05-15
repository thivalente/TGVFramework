using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class CEPTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CEP_Validar_NaoDeveSerVazio(string numero)
        {
            var ex = Assert.Throws<DomainException>(() => new CEP(numero));
            Assert.Equal("O CEP não deve ser vazio", ex.Message);

            ex = Assert.Throws<DomainException>(() => new CEP(numero));
            Assert.Equal("O CEP não deve ser vazio", ex.Message);
        }

        [Theory]
        [InlineData("xxx")]
        [InlineData("99999x999")]
        [InlineData("999")]
        public void CEP_Validar_NumeroInvalido(string numero)
        {
            var ex = Assert.Throws<DomainException>(() => new CEP(numero));
            Assert.Equal("O CEP está inválido", ex.Message);
        }

        [Theory]
        [InlineData("99999999")]
        [InlineData("99999-999")]
        public void CEP_Validar_Valido(string numero)
        {
            var cep = new CEP(numero);

            cep.Should().NotBeNull();
            cep.Numero.Should().Be(numero);
            cep.ToString().Should().Be("99999-999");
            cep.ToSomenteNumeros().Should().Be("99999999");
        }
    }
}
