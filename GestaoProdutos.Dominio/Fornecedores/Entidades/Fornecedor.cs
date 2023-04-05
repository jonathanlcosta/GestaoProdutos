using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Dominio.Fornecedores.Entidades
{
    public class Fornecedor
    {
        public virtual int Id { get; protected set;}
        public virtual string? Descricao { get; protected set;}
        public virtual string? Cnpj { get; protected set;}

        protected Fornecedor()
        {

        }

        public Fornecedor(string? descricao, string cnpj)
        {
            SetDescricaoFornecedor(descricao);
            SetCnpj(cnpj);
        }

        public virtual void SetDescricaoFornecedor(string? descricao)
        {
            if(String.IsNullOrWhiteSpace(descricao))
            {
                throw new ArgumentException("O nome do fornecedor é obrigatorio");
            }
            Descricao = descricao;
        }

         public virtual void SetCnpj(string cnpj)
    {
         if (String.IsNullOrWhiteSpace(cnpj))
                throw new ArgumentException("O CNPJ não pode ser vazio.");
            if (cnpj.Length != 14)
                throw new ArgumentException("O CNPJ deve conter 14 caracteres.");
                
            Cnpj = cnpj.Replace(".", "").Replace("/", "").Replace("-", "");
    }
    }
}