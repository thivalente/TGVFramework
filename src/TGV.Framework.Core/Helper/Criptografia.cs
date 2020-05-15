using System;
using System.Collections.Generic;

namespace TGV.Framework.Core.Helper
{
    public static class Criptografia
    {
        #region [ Propriedades ]

        private const string _charDivisor = "|";
        private const string _listaSpecialChar = @"1@2#3$4%5&6*7<8>9;{}[]\/_-=+aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ"; // Lista de caracteres especiais

        #endregion [ FIM - Propriedades ]

        #region [ Metodos ]

        public static string Criptografar(this string senha, string parametroSistema)
        {
            if (senha.IsNullOrEmptyOrWhiteSpace()) return String.Empty;

            // Insere os caracteres especiais baseado no parametro do sistema
            string senhaComCaracteresEspeciais = senha.InserirCaracteresEspeciais(parametroSistema);

            // Inverte o valor da senha
            string senhaInvertida = senhaComCaracteresEspeciais.Reverse();

            // Converte para base 64
            string senhaInvertida64 = EncodeTo64(senhaInvertida);

            // Inverte o valor da senha 64
            string senhaInvertida64Invertida = senhaInvertida64.Reverse();

            // Converte para base 64
            string senhaInvertida64Invertida64 = EncodeTo64(senhaInvertida64Invertida);

            // Adiciona o tamanho da senha no inicio da senha
            string senhaTamanhoSenha = senha.Length + _charDivisor + senhaInvertida64Invertida64;

            return senhaTamanhoSenha;
        }

        public static string Descriptografar(this string senhaInvertida64Invertida64, string parametroSistema)
        {
            if (senhaInvertida64Invertida64.IsNullOrEmptyOrWhiteSpace()) return String.Empty;

            int posicaoCharDivisor = senhaInvertida64Invertida64.IndexOf('|');

            // Obtém o tamanho da senha
            int tamanhoSenha = 0;
            string sTamanhoSenha = senhaInvertida64Invertida64.Substring(0, posicaoCharDivisor);
            Int32.TryParse(sTamanhoSenha, out tamanhoSenha);

            // Remove o tamanho da senha do inicio da senha
            string senhaSemTamanhoSenha = senhaInvertida64Invertida64.Substring(posicaoCharDivisor + 1);

            // Tira de base 64
            string senhaInvertida64Invertida = DecodeFrom64(senhaSemTamanhoSenha);

            // Inverte o valor da senha 64
            string senhaInvertida64 = senhaInvertida64Invertida.Reverse();

            // Tira da base 64
            string senhaInvertida = DecodeFrom64(senhaInvertida64);

            // Inverte o valor da senha
            string senha = senhaInvertida.Reverse();

            // Remove os caracteres especiais baseado no parametro do sistema
            string senhaSemCaracteresEspeciais = senha.RemoverCaracteresEspeciaisSenha(parametroSistema, tamanhoSenha);

            return senhaSemCaracteresEspeciais;
        }

        #region [ Privados ]

        private static string DecodeFrom64(string toDecode)
        {
            try
            {
                System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
                System.Text.Decoder utf8Decode = encoder.GetDecoder();

                byte[] todecode_byte = Convert.FromBase64String(toDecode);
                int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
                char[] decoded_char = new char[charCount];
                utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
                string result = new String(decoded_char);

                return result;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Decode" + e.Message);
            }
        }

        private static string EncodeTo64(string toEncode)
        {
            byte[] toEncodeAsBytes = System.Text.ASCIIEncoding.UTF8.GetBytes(toEncode);
            string returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
            return returnValue;
        }

        private static string InserirCaracteresEspeciais(this string senha, string parametroSistema)
        {
            int tamanhoSenha = senha.Length;

            foreach (KeyValuePair<string, int> item in ObterCaracteresPosicoesSenha(parametroSistema, tamanhoSenha))
            {
                senha = senha.Insert(item.Value, item.Key);
            }

            return senha;
        }

        private static Dictionary<string, int> ObterCaracteresPosicoesSenha(string parametroSistema, int tamanhoSenha)
        {
            Dictionary<string, int> dicRetorno = new Dictionary<string, int>();

            int posicaoInicial = parametroSistema.Length > 0 ? ObterPosicaoNumericaLetraAlfabeto(parametroSistema[0], _listaSpecialChar.Length) : 0; // Posição baseada no primeiro caractere do parametro do sistema
            int contador = 0;

            foreach (char cParametro in parametroSistema.ToCharArray())
            {
                // Define a posição em que o caractere especial será inserido
                int posicao = (posicaoInicial + contador) > _listaSpecialChar.Length - 1 ? 0 : (posicaoInicial + contador);

                // Obtem um caractere especial
                string specialCharSelecionado = _listaSpecialChar[posicao].ToString();
                contador++;

                // Insere na posição númerica da letra
                int startIndex = ObterPosicaoNumericaLetraAlfabeto(cParametro, tamanhoSenha);

                dicRetorno.Add(specialCharSelecionado, startIndex);
            }

            return dicRetorno;
        }

        private static int ObterPosicaoNumericaLetraAlfabeto(char letra, int maximo)
        {
            string letraLower = letra.ToString().ToLower();
            string alfabeto = @"abcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*()_+-=~{[}]:;'<,>.?/|\""";

            int posicao = 0;
            Math.DivRem(alfabeto.IndexOf(letraLower), maximo, out posicao);
            return posicao;
        }

        private static string RemoverCaracteresEspeciaisSenha(this string senha, string parametroSistema, int tamanhoSenha)
        {
            foreach (KeyValuePair<string, int> item in ObterCaracteresPosicoesSenha(parametroSistema.Reverse(), tamanhoSenha))
                senha = senha.Remove(item.Value, 1);

            return senha;
        }

        #endregion [ FIM - Privados ]

        #endregion [ FIM - Metodos ]
    }
}
