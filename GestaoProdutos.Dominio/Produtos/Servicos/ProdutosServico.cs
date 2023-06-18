using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
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
        public Produto Editar(int codigo, ProdutoComando comando)
        {
            Fornecedor fornecedor = fornecedoresServico.Validar(comando.IdFornecedor);
            Produto produto = Validar(codigo);
            produto.SetDescProduto(comando.Descricao);
            produto.SetDataFabricacao(comando.DataFabricacao);
            produto.SetDataValidade(comando.DataValidade);
            produto.SetFornecedor(fornecedor);
            produtosRepositorio.Editar(produto);
            return produto;
        }

        public Produto Inserir(ProdutoComando comando)
        {
            Produto produto = Instanciar(comando);
            produtosRepositorio.Inserir(produto);
            return produto;
        }

        public Produto Instanciar(ProdutoComando comando)
        {
            Fornecedor fornecedor = fornecedoresServico.Validar(comando.IdFornecedor);
            Produto produto = new(comando.Descricao, comando.DataFabricacao, comando.DataValidade, fornecedor);
            return produto;
        }

        public Produto Validar(int codigo)
        {
            Produto produto = this.produtosRepositorio.RecuperarProduto(codigo);
            if (produto is null)
            {
                throw new Exception("Produto não encontrado");
            }
            return produto;
        }
    }
}