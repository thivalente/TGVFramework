using System.Linq;

namespace TGV.Framework.Core.ValueObject
{
    public class Estado
    {
        #region [ Propriedades ]

        public int Id       { get; private set; }
        public string Nome  { get; private set; }
        public string UF    { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected Estado() { }

        public Estado(int id)
        {
            var es = new EstadoService();
            var estado = es.ListarTodos().FirstOrDefault(e => e.Id == id);

            Validar(estado.Id, estado.Nome, estado.UF);

            this.Id = estado.Id;
            this.Nome = estado.Nome;
            this.UF = estado.UF.ToUpper();
        }

        public Estado(int id, string nome, string uf)
        {
            Validar(id, nome, uf);

            this.Id = id;
            this.Nome = nome;
            this.UF = uf.ToUpper();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        internal static void Validar(Estado estado)
        {
            Validacoes.ValidarSeNulo(estado, "O Estado deve ser preenchido");

            Validar(estado.Id, estado.Nome, estado.UF);
        }

        internal static void Validar(int id, string nome, string uf)
        {
            Validacoes.ValidarMinimoMaximo(id, 1, 27, "O Id do Estado deve variar entre 1 e 27");
            Validacoes.ValidarSeVazio(nome, "O Nome do Estado não deve estar vazio");
            Validacoes.ValidarSeVazio(uf, "O UF do Estado não deve estar vazio");
            Validacoes.ValidarTamanho(uf, 2, 2, "O UF do Estado deve ter 2 caracteres");
        }

        #endregion [ FIM - Metodos ]
    }
}
