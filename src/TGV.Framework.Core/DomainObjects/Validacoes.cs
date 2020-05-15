using System;
using System.Text.RegularExpressions;

namespace TGV.Framework.Core.ValueObject
{
    public class Validacoes
    {
        #region [ Metodos ]

        #region [ ValidarMinimoMaximo ]

        public static void ValidarMinimoMaximo(DateTime valor, DateTime minimo, DateTime maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(decimal valor, decimal minimo, decimal maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(double valor, double minimo, double maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(float valor, float minimo, float maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(int valor, int minimo, int maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarMinimoMaximo(long valor, long minimo, long maximo, string mensagem)
        {
            if (valor < minimo || valor > maximo)
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarMinimoMaximo ]

        #region [ ValidarSeDiferente ]

        public static void ValidarSeDiferente(object obj1, object obj2, string mensagem)
        {
            if (!obj1.Equals(obj2))
                throw new DomainException(mensagem);
        }

        public static void ValidarSeDiferente(string pattern, string valor, string mensagem)
        {
            var regex = new Regex(pattern);

            if (String.IsNullOrEmpty(valor) || !regex.IsMatch(valor))
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarSeDiferente ]

        public static void ValidarSeFalso(bool boolValor, string mensagem)
        {
            if (!boolValor)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeIgual(object obj1, object obj2, string mensagem)
        {
            if (obj1.Equals(obj2))
                throw new DomainException(mensagem);
        }

        #region [ ValidarSeMaiorQue ]

        public static void ValidarSeMaiorQue(DateTime valor, DateTime maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMaiorQue(decimal valor, decimal maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMaiorQue(double valor, double maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMaiorQue(float valor, float maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMaiorQue(int valor, int maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMaiorQue(long valor, long maximo, string mensagem)
        {
            if (valor > maximo)
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarSeMaiorQue ]

        #region [ ValidarSeMenorQue ]

        public static void ValidarSeMenorQue(DateTime valor, DateTime minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(decimal valor, decimal minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(double valor, double minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(float valor, float minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(int valor, int minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeMenorQue(long valor, long minimo, string mensagem)
        {
            if (valor < minimo)
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarSeMenorQue ]

        public static void ValidarSeNulo(object obj1, string mensagem)
        {
            if (obj1 == null)
                throw new DomainException(mensagem);
        }

        #region [ ValidarSeVazio ]

        public static void ValidarSeVazio(Guid valor, string mensagem)
        {
            if (valor == null || valor == Guid.Empty)
                throw new DomainException(mensagem);
        }

        public static void ValidarSeVazio(string valor, string mensagem)
        {
            if (valor == null || valor.Trim().Length == 0)
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarSeVazio ]

        public static void ValidarSeVerdadeiro(bool boolValor, string mensagem)
        {
            if (boolValor)
                throw new DomainException(mensagem);
        }

        #region [ ValidarTamanho ]

        public static void ValidarTamanho(string valor, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;

            if (length > maximo)
                throw new DomainException(mensagem);
        }

        public static void ValidarTamanho(string valor, int minimo, int maximo, string mensagem)
        {
            var length = valor.Trim().Length;

            if (length < minimo || length > maximo)
                throw new DomainException(mensagem);
        }

        #endregion [ FIM - ValidarTamanho ]

        #endregion [ FIM - Metodos ]
    }
}
