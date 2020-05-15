using FluentAssertions;
using TGV.Framework.Core.Helper;
using Xunit;

namespace TGV.Framework.Core.Tests
{
    public class CriptografiaTest
    {
        [Fact]
        public void Criptografia_Validar_Criptografar()
        {
            var valorInicial = "Thiago Gonçalves Valente";
            var parametroSistema = "TGVFramework";

            var result = valorInicial.Criptografar(parametroSistema);
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("24|PT13WFVoV2E5RTJaYzkyV2lCeVJ2MVNZdWQ2d0JGR2IyVjJMenRDSVdGV2ZkeFdadVJYWg==");
        }

        [Fact]
        public void Criptografia_Validar_Descriptografar()
        {
            var valorInicial = "24|PT13WFVoV2E5RTJaYzkyV2lCeVJ2MVNZdWQ2d0JGR2IyVjJMenRDSVdGV2ZkeFdadVJYWg==";
            var parametroSistema = "TGVFramework";

            var result = valorInicial.Descriptografar(parametroSistema);
            result.Should().NotBeNullOrEmpty();
            result.Should().Be("Thiago Gonçalves Valente");
        }
    }
}
