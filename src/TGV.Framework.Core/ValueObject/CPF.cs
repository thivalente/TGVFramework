using System;
using System.Linq;
using TGV.Framework.Core.ValueObject;

namespace TGV.Framework.Core.ValueObject
{
    public class CPF
    {
        #region [ Propriedades ]

        public string Codigo { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected CPF() { }

        public CPF(string codigo)
        {
            this.Codigo = codigo;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public string ToSomenteNumeros()
        {
            return String.IsNullOrEmpty(this.Codigo) ? null : new string(this.Codigo.Where(c => char.IsDigit(c)).ToArray());
        }

        public override string ToString()
        {
            return Convert.ToUInt64(this.Codigo.Replace(".", "").Replace("-", "")).ToString(@"000\.000\.000\-00");
        }

        private static bool IsCpf(string cpf)
        {
            if (String.IsNullOrWhiteSpace(cpf)) return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            string tempCpf = cpf.Substring(0, 9);
            int soma = 0;

            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

            int resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            string digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

            resto = soma % 11;

            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;

            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        private void Validar()
        {
            if (!IsCpf(this.Codigo))
                throw new DomainException("O CPF está inválido");
        }

        #endregion [ FIM - Metodos ]
    }
}
