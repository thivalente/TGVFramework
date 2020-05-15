using TGV.Framework.Core.ValueObject;
using System;
using System.Linq;

namespace TGV.Framework.Core.ValueObject
{
    public class Telefone
    {
        #region [ Propriedades ]

        public string Numero    { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        public Telefone(string numero = null)
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
            if (String.IsNullOrEmpty(this.Numero))
                return String.Empty;

            string somenteNumeros = this.ToSomenteNumeros();

            long nroFone = 0;
            Int64.TryParse(somenteNumeros, out nroFone);

            if (somenteNumeros.Length == 11 && somenteNumeros.StartsWith("0800"))
                return String.Format("{0:### ###-####}", Convert.ToInt64(nroFone)).Replace("800", "0800");
            if (somenteNumeros.Length == 11)
                return String.Format("{0:(##) #####-####}", nroFone);

            return String.Format("{0:(##) ####-####}", nroFone);
        }

        private void Validar()
        {
            if (!String.IsNullOrEmpty(this.Numero))
                Validacoes.ValidarSeDiferente(@"^(?:(?:\+|00)?(55)\s?)?(?:\(?([1-9][0-9])\)?\s?)?(?:((?:9\d|[2-9])\d{3})\-?(\d{4}))$", this.Numero, "O Número do Telefone está inválido");
        }

        #endregion [ FIM - Metodos ]
    }
}
