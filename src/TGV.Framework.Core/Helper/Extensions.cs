using System;

namespace TGV.Framework.Core.Helper
{
    public static class Extensions
    {
        #region [ Metodos ]

        public static bool IsNullOrEmptyOrWhiteSpace(this String valor)
        {
            return String.IsNullOrEmpty(valor) || String.IsNullOrWhiteSpace(valor);
        }

        public static string Reverse(this string str)
        {
            char[] charArray = str.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        #endregion [ FIM - Metodos ]
    }
}
