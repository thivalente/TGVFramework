using TGV.Framework.Core.ValueObject;

namespace TGV.Framework.Core.ValueObject
{
    public class Email
    {
        #region [ Propriedades ]

        public string Endereco { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected Email() { }

        public Email(string endereco)
        {
            this.Endereco = endereco;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override string ToString()
        {
            return this.Endereco;
        }

        private void Validar()
        {
            Validacoes.ValidarSeDiferente(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", this.Endereco, "O Endereço de E-mail está inválido");
        }

        #endregion [ FIM - Metodos ]
    }
}
