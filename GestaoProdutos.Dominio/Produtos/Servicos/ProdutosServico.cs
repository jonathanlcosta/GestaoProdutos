using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Execoes;
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
        public async Task<Produto> EditarAsync(int codigo, ProdutoComando comando)
        {
            Fornecedor fornecedor = await fornecedoresServico.ValidarAsync(comando.IdFornecedor);
            Produto produto = await ValidarAsync(codigo);
            produto.SetDescProduto(comando.Descricao);
            produto.SetDataFabricacao(comando.DataFabricacao);
            produto.SetDataValidade(comando.DataValidade);
            produto.SetFornecedor(fornecedor);
            await produtosRepositorio.EditarAsync(produto);
            return produto;
        }

        public async Task<Produto> InserirAsync(ProdutoComando comando)
        {
            Produto produto = await InstanciarAsync(comando);
            await produtosRepositorio.InserirAsync(produto);
            return produto;
        }

        public async Task<Produto> InstanciarAsync(ProdutoComando comando)
        {
            Fornecedor fornecedor = await fornecedoresServico.ValidarAsync(comando.IdFornecedor);
            Produto produto = new(comando.Descricao, comando.DataFabricacao, comando.DataValidade, fornecedor);
            return produto;
        }

        public async Task<Produto> ValidarAsync(int codigo)
        {
            Produto produto = await produtosRepositorio.RecuperarProdutoAsync(codigo);
            if (produto is null)
            {
                throw new RegraDeNegocioExcecao("Produto não encontrado");
            }
            return produto;
        }

        public async Task<Produto> RecuperarPorDescricaoAsync(string descricao)
        {
            return await produtosRepositorio.RecuperarPorDescricaoAsync(descricao);
        }
    }
}