using System;
using TGV.Framework.Core.ValueObject;

namespace TGV.Framework.Core.ValueObject
{
    public class CarteiraTrabalho
    {
        #region [ Propriedades ]

        public string Numero    { get; private set; }
        public string Serie     { get; private set; }
        public Estado Estado    { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        protected CarteiraTrabalho() { }

        public CarteiraTrabalho(string numero, string serie, Estado estado)
        {
            this.Numero = numero;
            this.Serie = serie;
            this.Estado = estado;

            Validar();
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override string ToString()
        {
            return $"{this.Numero} / {this.Serie} / {this.Estado.UF}";
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
            Validacoes.ValidarSeVazio(this.Numero, "O Número da Carteira de Trabalho não deve estar vazio");
            Validacoes.ValidarSeVazio(this.Serie, "A Série da Carteira de Trabalho não pode ser vazia");
            Validacoes.ValidarSeNulo(this.Estado, "O Estado da Carteira de Trabalho não deve estar vazio");
        }

        #endregion [ FIM - Metodos ]
    }
}
