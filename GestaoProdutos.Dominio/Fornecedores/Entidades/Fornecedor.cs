using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Execoes;

namespace GestaoProdutos.Dominio.Fornecedores.Entidades
{
    public class Fornecedor
    {
        public virtual int Id { get; protected set;}
        public virtual string Descricao { get; protected set;}
        public virtual string Cnpj { get; protected set;}

        protected Fornecedor()
        {

        }

        public Fornecedor(string descricao, string cnpj)
        {
            SetDescricaoFornecedor(descricao);
            SetCnpj(cnpj);
        }

        public virtual void SetDescricaoFornecedor(string descricao)
        {
            if(String.IsNullOrWhiteSpace(descricao))
            {
                throw new AtributoObrigatorioExcecao("Descrição");
            }
            Descricao = descricao;
        }

         public virtual void SetCnpj(string cnpj)
    {
         if (String.IsNullOrWhiteSpace(cnpj))
                throw new AtributoObrigatorioExcecao("CNPJ");
            if (cnpj.Length != 14)
                throw new TamanhoDeAtributoInvalidoExcecao("CNPJ", 14, 14);
                
            Cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
    }
    }
}