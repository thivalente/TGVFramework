using TGV.Framework.Core.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace TGV.Framework.Core.ValueObject
{
    public class RG
    {
        #region [ Propriedades ]

        public string Codigo            { get; private set; }
        public DateTime DataExpedicao   { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected RG() { }

        public RG(string codigo, DateTime dataExpedicao)
        {
            this.Codigo = codigo;
            this.DataExpedicao = dataExpedicao;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override string ToString()
        {
            return this.Codigo;
        }

        private void Validar()
        {
            Validacoes.ValidarSeVazio(this.Codigo, "O RG não deve estar vazio");
            Validacoes.ValidarSeMaiorQue(this.DataExpedicao, DateTime.Today, "A Data de Expedição do RG deve ser menor do que hoje");
        }

        #endregion [ FIM - Metodos ]
    }
}
