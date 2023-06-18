using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;

namespace GestaoProdutos.Dominio.Produtos.Entidades
{
    public class Produto
    {
        public virtual int Codigo {get; protected set;}
        public virtual string Descricao {get; protected set;}
        public virtual SituacaoProdutoEnum Situacao {get; protected set;}
        public virtual DateTime DataFabricacao {get; protected set;}
        public virtual DateTime DataValidade {get; protected set;}
        public virtual Fornecedor Fornecedor {get; protected set;}

        protected Produto()
        {
            
        }

        public Produto(string descricao, DateTime dataFabricacao, DateTime dataValidade, Fornecedor fornecedor)
        {
            SetDescProduto(descricao);
            SetSituacao(SituacaoProdutoEnum.Ativo);
            SetDataValidade(dataValidade);
            SetDataFabricacao(dataFabricacao);
            SetFornecedor(fornecedor);
        }


        public virtual void SetDescProduto(string descricao)
        {
            if (string.IsNullOrWhiteSpace(descricao))
            {
                throw new AtributoObrigatorioExcecao("Descrição");
            }
            Descricao = descricao;
        }

        public virtual void SetSituacao(SituacaoProdutoEnum situacao)
        {
            Situacao = situacao;
        }
    
        public virtual void SetDataFabricacao(DateTime dataFabricacao)
        {
             if (dataFabricacao == DateTime.MinValue)
            {
                throw new AtributoObrigatorioExcecao("Data");
            }
            if (dataFabricacao.CompareTo(this.DataValidade) > 0 || dataFabricacao.CompareTo(this.DataValidade) == 0)
            {
                throw new RegraDeNegocioExcecao("A data de fabricacao nao pode ser anterior ou na mesma data que a data de validade");
            }
            DataFabricacao = dataFabricacao;
        }
    
        public virtual void SetDataValidade(DateTime dataValidade)
        {
             if (dataValidade == DateTime.MinValue)
            {
                throw new AtributoObrigatorioExcecao("Data");
            }
            DataValidade = dataValidade;
        }

        public virtual void SetFornecedor(Fornecedor fornecedor)
        {
            if (fornecedor is null)
            {
                throw new AtributoObrigatorioExcecao("Fornecedor");
            }
            Fornecedor = fornecedor;
        }
    }
}