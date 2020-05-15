using System;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class ValidacoesTest
    {
        [Fact]
        public void Validacoes_Validar_ValidarSeMenorQueDateTime()
        {
            var ex = Assert.Throws<DomainException>(() => Validacoes.ValidarSeMenorQue(DateTime.Now.AddYears(-17), DateTime.Now, "Erro na data"));
            Assert.Equal("Erro na data", ex.Message);
        }

        [Fact]
        public void Validacoes_Validar_ValidarSeMaiorQueDateTime()
        {
            var ex = Assert.Throws<DomainException>(() => Validacoes.ValidarSeMaiorQue(DateTime.Now, DateTime.Now.AddYears(-17), "Erro na data"));
            Assert.Equal("Erro na data", ex.Message);
        }
    }
}
