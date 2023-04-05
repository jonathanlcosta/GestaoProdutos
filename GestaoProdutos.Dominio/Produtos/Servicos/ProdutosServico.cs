using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Produtos.Servicos
{
    public class ProdutosServico : IProdutosServico
    {
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly IProdutosRepositorio produtosRepositorio;
        public ProdutosServico(IProdutosRepositorio produtosRepositorio, IFornecedoresServico fornecedoresServico)
        {
            this.produtosRepositorio = produtosRepositorio;
            this.fornecedoresServico = fornecedoresServico;
        }
        public Produto Editar(int codigo, string descricao, DateTime dataFabricacao, DateTime dataValidade, int idFornecedor)
        {
            var fornecedor = fornecedoresServico.Validar(idFornecedor);
           var produto = Validar(codigo);
            if(!string.IsNullOrWhiteSpace(descricao) && produto.Descricao != descricao) produto.SetDescProduto(descricao);
            produto.SetDataFabricacao(dataFabricacao);
            produto.SetDataValidade(dataValidade);
            if(fornecedor is not null) produto.SetFornecedor(fornecedor);
            produto = produtosRepositorio.Editar(produto);
            return produto;
        }

        public Produto Inserir(Produto produto)
        {
             var produtoResponse = produtosRepositorio.Inserir(produto);
            return produtoResponse;
        }

        public Produto Instanciar(string descricao, DateTime dataFabricacao, DateTime dataValidade, int idFornecedor)
        {
           Fornecedor fornecedor = fornecedoresServico.Validar(idFornecedor);


            var produtoResponse = new Produto(descricao, dataFabricacao, dataValidade, fornecedor);
            return produtoResponse;
        }

        public Produto Validar(int codigo)
        {
            var produtoResponse = this.produtosRepositorio.RecuperarProduto(codigo);
            if(produtoResponse is null)
            {
                 throw new Exception("Produto não encontrado");
            }
            return produtoResponse;
        }
    }
}