using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class CarteiraTrabalhoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CarteiraTrabalho_Validar_NumeroCarteiraNaoPodeSerVazio(string numero)
        {
            var ex = Assert.Throws<DomainException>(() => new CarteiraTrabalho(numero, "Serie", new Estado(26, "S�o Paulo", "SP")));
            Assert.Equal("O N�mero da Carteira de Trabalho n�o deve estar vazio", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void CarteiraTrabalho_Validar_SerieCarteiraNaoPodeSerVazio(string serie)
        {
            var ex = Assert.Throws<DomainException>(() => new CarteiraTrabalho("Numero", serie, new Estado(26, "S�o Paulo", "SP")));
            Assert.Equal("A S�rie da Carteira de Trabalho n�o pode ser vazia", ex.Message);

            ex = Assert.Throws<DomainException>(() => new CarteiraTrabalho("Numero", "Serie", null));
            Assert.Equal("O Estado da Carteira de Trabalho n�o deve estar vazio", ex.Message);
        }

        [Fact]
        public void CarteiraTrabalho_Validar_EstadoNaoPodeSerVazio()
        {
            var ex = Assert.Throws<DomainException>(() => new CarteiraTrabalho("Numero", "Serie", null));
            Assert.Equal("O Estado da Carteira de Trabalho n�o deve estar vazio", ex.Message);
        }

        [Fact]
        public void CarteiraTrabalho_Validar_Valido()
        {
            string numero = "Numero";
            string serie = "Serie";
            Estado estado = new Estado(26, "S�o Paulo", "SP");

            var ct = new CarteiraTrabalho(numero, serie, estado);

            ct.Should().NotBeNull();
            ct.Numero.Should().Be(numero);
            ct.Serie.Should().Be(serie);
            ct.Estado.Should().BeSameAs(estado);
        }
    }
}
