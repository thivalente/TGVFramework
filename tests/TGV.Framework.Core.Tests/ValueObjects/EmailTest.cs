using FluentAssertions;
using TGV.Framework.Core.ValueObject;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class EmailTest
    {
        [Fact]
        public void Email_Validar_FormatoInvalido()
        {
            var ex = Assert.Throws<DomainException>(() => new Email("teste"));
            Assert.Equal("O Endereço de E-mail está inválido", ex.Message);
        }

        [Fact]
        public void Email_Validar_ToString()
        {
            string endereco = "a@b.com.br";

            var novoEmail = new Email(endereco);

            novoEmail.Endereco.Should().Be(endereco);
            novoEmail.ToString().Should().Be(endereco);
        }
    }
}
