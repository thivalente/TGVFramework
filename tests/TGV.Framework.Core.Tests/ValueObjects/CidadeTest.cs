using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class CidadeTest
    {
        #region [ Construtor Completo ]

        [Fact]
        public void Cidade_Validar_IdDeveSerMaiorQueZero()
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(0, "São Paulo", new Estado(1, "São Paulo", "SP")));
            Assert.Equal("O Id da Cidade deve ser maior do que 0", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Cidade_Validar_NomeNaoDeveEstarVazio(string nome)
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(1, nome, new Estado(1, "São Paulo", "SP")));
            Assert.Equal("O Nome da Cidade não deve estar vazio", ex.Message);
        }

        [Fact]
        public void Cidade_Validar_EstadoNaoPodeSerVazio()
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(1, "São Paulo", null));
            Assert.Equal("O Estado da Cidade não deve estar vazio", ex.Message);
        }

        [Fact]
        public void Cidade_Validar_Valida()
        {
            int id = 1;
            string nome = "São Paulo";
            Estado estado = new Estado(26, "São Paulo", "SP");

            var cidade = new Cidade(id, nome, estado);

            cidade.Id.Should().Be(id);
            cidade.Nome.Should().Be(nome);
            cidade.Estado.Should().BeSameAs(estado);
            cidade.ToString().Should().Be($"{nome}/{estado.UF}");
        }

        #endregion [ FIM - Construtor Completo ]

        [Fact]
        public void Cidade_Validar_ConstrutorEstadoId_IdDeveSerMaiorQueZero()
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(0, "São Paulo", 1));
            Assert.Equal("O Id da Cidade deve ser maior do que 0", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Cidade_Validar_ConstrutorEstadoId_NomeNaoDeveEstarVazio(string nome)
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(1, nome, 1));
            Assert.Equal("O Nome da Cidade não deve estar vazio", ex.Message);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(28)]
        public void Cidade_Validar_ConstrutorEstadoId_EstadoDeveEstarDentroRange(int estadoId)
        {
            var ex = Assert.Throws<DomainException>(() => new Cidade(1, "São Paulo", estadoId));
            Assert.Equal("O Estado deve ser preenchido", ex.Message);
        }

        [Fact]
        public void Cidade_Validar_ConstrutorEstadoId_Valida()
        {
            int id = 1;
            string nome = "São Paulo";
            int estadoId = 26;

            var cidade = new Cidade(id, nome, estadoId);

            cidade.Id.Should().Be(id);
            cidade.Nome.Should().Be(nome);
            
            cidade.Estado.Should().NotBeNull();
            cidade.Estado.Id.Should().Be(estadoId);
            cidade.Estado.Nome.Should().Be("São Paulo");
            cidade.Estado.UF.Should().Be("SP");

            cidade.ToString().Should().Be($"{nome}/{cidade.Estado.UF}");
        }
    }
}
