using System.Collections.Generic;

namespace TGV.Framework.Core.ValueObject
{
    public class EstadoService : IEstadoService
    {
        public List<Estado> ListarTodos()
        {
            List<Estado> estados = new List<Estado>();

            estados.Add(new Estado(1, "Acre", "AC"));
            estados.Add(new Estado(2, "Alagoas", "AL"));
            estados.Add(new Estado(3, "Amazonas", "AM"));
            estados.Add(new Estado(4, "Amapá", "AP"));
            estados.Add(new Estado(5, "Bahia", "BA"));
            estados.Add(new Estado(6, "Ceará", "CE"));
            estados.Add(new Estado(7, "Distrito Federal", "DF"));
            estados.Add(new Estado(8, "Espírito Santo", "ES"));
            estados.Add(new Estado(9, "Goiás", "GO"));
            estados.Add(new Estado(10, "Maranhão", "MA"));
            estados.Add(new Estado(11, "Minas Gerais", "MG"));
            estados.Add(new Estado(12, "Mato Grosso do Sul", "MS"));
            estados.Add(new Estado(13, "Mato Grosso", "MT"));
            estados.Add(new Estado(14, "Pará", "PA"));
            estados.Add(new Estado(15, "Paraíba", "PB"));
            estados.Add(new Estado(16, "Pernambuco", "PE"));
            estados.Add(new Estado(17, "Piauí", "PI"));
            estados.Add(new Estado(18, "Paraná", "PR"));
            estados.Add(new Estado(19, "Rio de Janeiro", "RJ"));
            estados.Add(new Estado(20, "Rio Grande do Norte", "RN"));
            estados.Add(new Estado(21, "Rondônia", "RO"));
            estados.Add(new Estado(22, "Roraima", "RR"));
            estados.Add(new Estado(23, "Rio Grande do Sul", "RS"));
            estados.Add(new Estado(24, "Santa Catarina", "SC"));
            estados.Add(new Estado(25, "Sergipe", "SE"));
            estados.Add(new Estado(26, "São Paulo", "SP"));
            estados.Add(new Estado(27, "Tocantins", "TO"));

            return estados;
        }
    }
}
