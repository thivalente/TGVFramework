using FluentAssertions;
using System;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class EnderecoTest
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Endereco_Validar_LogradouroNaoDeveEstarVazio(string logradouro)
        {
            var ex = Assert.Throws<DomainException>(() => new Endereco(logradouro, "1", null, "centro", new CEP("99999999"), new Cidade(1, "Cidade", new Estado(26, "São Paulo", "SP"))));
            Assert.Equal("O Logradouro do Endereço não deve estar vazio", ex.Message);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        public void Endereco_Validar_BairroNaoDeveEstarVazio(string bairro)
        {
            var ex = Assert.Throws<DomainException>(() => new Endereco("Rua ABC", "1", null, bairro, new CEP("99999999"), new Cidade(1, "Cidade", new Estado(26, "São Paulo", "SP"))));
            Assert.Equal("O Bairro do Endereço não deve estar vazio", ex.Message);
        }

        [Fact]
        public void Endereco_Validar_CEPNaoPodeSerVazio()
        {
            var ex = Assert.Throws<DomainException>(() => new Endereco("Rua ABC", "1", null, "centro", null, new Cidade(1, "Cidade", new Estado(26, "São Paulo", "SP"))));
            Assert.Equal("O CEP do Endereço não deve estar vazio", ex.Message);
        }

        [Fact]
        public void Endereco_Validar_CidadeNaoPodeSerVazia()
        {
            var ex = Assert.Throws<DomainException>(() => new Endereco("Rua ABC", "1", null, "centro", new CEP("99999999"), null));
            Assert.Equal("A Cidade do Endereço não deve estar vazia", ex.Message);
        }

        [Theory]
        [InlineData("Ap 21")]
        [InlineData(null)]
        [InlineData("")]
        public void Endereco_Validar_ValidoComNumero(string complemento)
        {
            string logradouro = "Rua ABC";
            string numero = "123";
            string bairro = "Centro";
            CEP cep = new CEP("99999999");
            Cidade cidade = new Cidade(1, "São Paulo", new Estado(26, "São Paulo", "SP"));
            string complementoFormatado = String.IsNullOrEmpty(complemento) ? String.Empty : $" - {complemento}";

            var endereco = new Endereco(logradouro, numero, complemento, bairro, cep, cidade);

            endereco.Should().NotBeNull();
            endereco.Logradouro.Should().Be(logradouro);
            endereco.Numero.Should().Be(numero);
            endereco.Complemento.Should().Be(complemento);
            endereco.Bairro.Should().Be(bairro);
            endereco.CEP.Should().BeSameAs(cep);
            endereco.Cidade.Should().BeSameAs(cidade);
            endereco.ToString().Should().Be($"{logradouro}, {numero}{complementoFormatado} - {bairro} - {cidade.ToString()} - CEP: {cep.ToString()}");
        }
    }
}
