using FluentAssertions;
using System;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class TelefoneTest
    {
        [Theory]
        
        [InlineData("xxxx")]
        [InlineData("123")]
        public void Telefone_Validar_FormatoInvalido(string numero)
        {
            var ex = Assert.Throws<DomainException>(() => new Telefone(numero));
            Assert.Equal("O Número do Telefone está inválido", ex.Message);
        }

        [Theory]
        [InlineData("(99) 99999-9999")]
        [InlineData("(99) 9999-9999")]
        [InlineData("(11) 2111-1111")]
        public void Telefone_Validar_ComNumeroPreenchidoCorretamente(string numero)
        {
            var telefone = new Telefone(numero);

            telefone.Numero.Should().Be(numero);
            telefone.ToString().Should().Be(numero);
            telefone.ToSomenteNumeros().Should().Be(numero.Replace(" ", "").Replace("(", "").Replace(")", "").Replace("-", ""));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Telefone_Validar_ComNumeroVazio(string numero)
        {
            var telefone = new Telefone(numero);

            telefone.Numero.Should().Be(numero);
            telefone.ToString().Should().Be(String.Empty);
            telefone.ToSomenteNumeros().Should().Be(null);
        }
    }
}
