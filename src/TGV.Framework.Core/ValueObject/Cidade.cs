using System.Linq;

namespace TGV.Framework.Core.ValueObject
{
    public class Cidade
    {
        #region [ Propriedades ]

        public int Id           { get; set; }
        public string Nome      { get; set; }
        public Estado Estado    { get; set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        public Cidade(int id, string nome, int estadoId)
        {
            this.Id = id;
            this.Nome = nome;

            var es = new EstadoService();
            var estado = es.ListarTodos().FirstOrDefault(e => e.Id == estadoId);
            Estado.Validar(estado);

            this.Estado = estado;

            Validar();
        }

        public Cidade(int id, string nome, Estado estado)
        {
            this.Id = id;
            this.Nome = nome;
            this.Estado = estado;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override string ToString()
        {
            return $"{this.Nome}/{this.Estado.UF}";
        }

        private void Validar()
        {
            Validacoes.ValidarSeMenorQue(this.Id, 1, "O Id da Cidade deve ser maior do que 0");
            Validacoes.ValidarSeVazio(this.Nome, "O Nome da Cidade não deve estar vazio");
            Validacoes.ValidarSeNulo(this.Estado, "O Estado da Cidade não deve estar vazio");
        }

        #endregion [ FIM - Metodos ]
    }
}
