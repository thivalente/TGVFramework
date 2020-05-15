using System;
using System.Collections.Generic;
using System.Text;

namespace TGV.Framework.Core.ValueObject
{
    public class Endereco
    {
        #region [ Propriedades ]

        public string Logradouro    { get; private set; }
        public string Numero        { get; private set; }
        public string Complemento   { get; private set; }
        public string Bairro        { get; private set; }
        public CEP CEP              { get; private set; }
        public int CidadeId         { get; private set; }

        public Cidade Cidade        { get; private set; }

        #endregion [ FIM - Propriedades ]

        #region [ Construtores ]

        public Endereco(string logradouro, string numero, string complemento, string bairro, CEP cep, int cidadeId)
        {
            if (String.IsNullOrEmpty(this.Numero))
                this.Numero = "S/N";

            Validar(logradouro, bairro, cep, cidadeId);

            this.Logradouro = logradouro.Trim();
            this.Numero = numero.Trim();
            this.Complemento = complemento?.Trim();
            this.Bairro = bairro.Trim();
            this.CEP = cep;
            this.CidadeId = cidadeId;
        }

        public Endereco(string logradouro, string numero, string complemento, string bairro, CEP cep, Cidade cidade)
        {
            if (String.IsNullOrEmpty(this.Numero))
                this.Numero = "S/N";

            Validar(logradouro, bairro, cep, cidade);

            this.Logradouro = logradouro.Trim();
            this.Numero = numero.Trim();
            this.Complemento = complemento?.Trim();
            this.Bairro = bairro.Trim();
            this.CEP = cep;
            this.Cidade = cidade;
        }

        #endregion [ FIM - Construtores ]

        #region [ Metodos ]

        public override string ToString()
        {
            string complemento = String.Empty;

            if (!String.IsNullOrEmpty(this.Complemento))
                complemento = $" - {this.Complemento}";

            if (this.Cidade != null)
                return $"{this.Logradouro}, {this.Numero}{complemento} - {this.Bairro} - {this.Cidade.ToString()} - CEP: {this.CEP.ToString()}";
            else
                return $"{this.Logradouro}, {this.Numero}{complemento} - {this.Bairro} - CEP: {this.CEP.ToString()}";
        }

        private void Validar(string logradouro, string bairro, CEP cep, int cidadeId)
        {
            Validacoes.ValidarSeVazio(logradouro, "O Logradouro do Endereço não deve estar vazio");
            Validacoes.ValidarSeVazio(bairro, "O Bairro do Endereço não deve estar vazio");
            Validacoes.ValidarSeNulo(cep, "O CEP do Endereço não deve estar vazio");
            Validacoes.ValidarSeMenorQue(cidadeId, 1, "O Id da Cidade deve ser maior do que 0");

            if (this.Cidade != null)
                Validacoes.ValidarSeDiferente(this.Cidade.Id, cidadeId, "O Id da Cidade está incompatível");
        }

        private void Validar(string logradouro, string bairro, CEP cep, Cidade cidade)
        {
            Validacoes.ValidarSeVazio(logradouro, "O Logradouro do Endereço não deve estar vazio");
            Validacoes.ValidarSeVazio(bairro, "O Bairro do Endereço não deve estar vazio");
            Validacoes.ValidarSeNulo(cep, "O CEP do Endereço não deve estar vazio");
            Validacoes.ValidarSeNulo(cidade, "A Cidade do Endereço não deve estar vazia");
        }

        #endregion [ FIM - Metodos ]
    }
}
