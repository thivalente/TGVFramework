using FluentAssertions;
using System;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class RGTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void RG_Validar_CodigoNaoDeveEstarVazio(string codigo)
        {
            var ex = Assert.Throws<DomainException>(() => new RG(codigo, DateTime.Today));
            Assert.Equal("O RG não deve estar vazio", ex.Message);
        }

        [Fact]
        public void RG_Validar_DataExpedicaoNaoDeveSerMaiorQueHoje()
        {
            var ex = Assert.Throws<DomainException>(() => new RG("teste", DateTime.Now));
            Assert.Equal("A Data de Expedição do RG deve ser menor do que hoje", ex.Message);
        }

        [Fact]
        public void RG_Validar_Valido()
        {
            var codigo = "329038096";
            
            var rg = new RG(codigo, DateTime.Today);

            rg.Codigo.Should().Be(codigo);
            rg.ToString().Should().Be(codigo);
            rg.DataExpedicao.Should().Be(DateTime.Today);
        }
    }
}
