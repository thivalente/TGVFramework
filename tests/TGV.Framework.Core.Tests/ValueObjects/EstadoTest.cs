using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class EstadoTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(28)]
        public void Estado_Validar_IdDeveEstarEntre1e27(int id)
        {
            var ex = Assert.Throws<DomainException>(() => new Estado(id, "São Paulo", "SP"));
            Assert.Equal("O Id do Estado deve variar entre 1 e 27", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Estado_Validar_NomeNaoDeveEstarVazio(string nome)
        {
            var ex = Assert.Throws<DomainException>(() => new Estado(26, nome, "SP"));
            Assert.Equal("O Nome do Estado não deve estar vazio", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Estado_Validar_UFNaoDeveEstarVazio(string uf)
        {
            var ex = Assert.Throws<DomainException>(() => new Estado(26, "São Paulo", uf));
            Assert.Equal("O UF do Estado não deve estar vazio", ex.Message);
        }

        [Theory]
        [InlineData("xxx")]
        [InlineData("x")]
        public void Estado_Validar_UFDeveTerDoisCaracteres(string uf)
        {
            var ex = Assert.Throws<DomainException>(() => new Estado(1, "São Paulo", uf));
            Assert.Equal("O UF do Estado deve ter 2 caracteres", ex.Message);
        }

        [Fact]
        public void Estado_Validar_Valido()
        {
            int id = 1;
            string nome = "São Paulo";
            string uf = "sp";

            var estado = new Estado(id, nome, uf);

            estado.Id.Should().Be(id);
            estado.Nome.Should().Be(nome);
            estado.UF.Should().Be(uf.ToUpper());
        }
    }
}
