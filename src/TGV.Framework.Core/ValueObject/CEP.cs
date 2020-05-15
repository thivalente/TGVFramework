using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TGV.Framework.Core.ValueObject;

namespace TGV.Framework.Core.ValueObject
{
    public class CEP
    {
        #region [ Propriedades ]

        public string Numero { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected CEP() { }

        public CEP(string numero)
        {
            this.Numero = numero;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public string ToSomenteNumeros()
        {
            return String.IsNullOrEmpty(this.Numero) ? null : new string(this.Numero.Where(c => char.IsDigit(c)).ToArray());
        }

        public override string ToString()
        {
            long cep;
            Int64.TryParse(ToSomenteNumeros(), out cep);

            return String.Format("{0:#####-###}", cep);
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(this.Numero, "O CEP não deve ser vazio");
            Validacoes.ValidarSeDiferente("[0-9]{5}(-)?[0-9]{3}", this.Numero, "O CEP está inválido");
        }

        #endregion [ FIM - Metodos ]
    }
}
