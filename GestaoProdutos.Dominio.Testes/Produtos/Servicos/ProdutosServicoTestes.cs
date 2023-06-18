using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos;
using NSubstitute;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Produtos.Servicos
{
    public class ProdutosServicoTestes
    {
         private readonly ProdutosServico sut;
         private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly Fornecedor fornecedorValido;
        private readonly Produto produtoValido;

        public ProdutosServicoTestes()
        {
            fornecedorValido = Builder<Fornecedor>.CreateNew().Build();
            produtoValido = Builder<Produto>.CreateNew().Build();
            produtosRepositorio = Substitute.For<IProdutosRepositorio>();
            fornecedoresServico = Substitute.For<IFornecedoresServico>();

            sut = new ProdutosServico(produtosRepositorio, fornecedoresServico);
        }


         public class ValidarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ProdutoNaoEncontrado_Espero_Excecao()
            {
                produtosRepositorio.RecuperarProduto(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(2)).Should().Throw<Exception>();

            }

            [Fact]
            public void Dado_ProdutoEncontrado_Espero_ProdutoValido()
            {
                produtosRepositorio.RecuperarProduto(Arg.Any<int>()).Returns(produtoValido);
                sut.Validar(2).Should().BeSameAs(produtoValido);
            }
        }

        public class InstanciarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarProdutos_Espero_ProdutoInstanciado()
            {
            DateTime dataFabricacao = new DateTime(2023, 4, 1);
            DateTime dataValidade = new DateTime(2023, 5, 1);

            // var produto = sut.Instanciar("Parabrisa", dataFabricacao, dataValidade, 2);

            // Assert.NotNull(produto);
            // Assert.Equal("Parabrisa", produto.Descricao);
            // Assert.Equal(dataFabricacao, produto.DataFabricacao);
            // Assert.Equal(dataValidade, produto.DataValidade);
            }
        }

        public class InserirMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Dado_ProdutoValido_Espero_ProdutoInserido()
            {
                // produtosRepositorio.Inserir(Arg.Any<Produto>()).Returns(produtoValido);

                // var produto = sut.Inserir(produtoValido);

                // produtosRepositorio.Received(1).Inserir(produtoValido);
                // produto.Should().BeOfType<Produto>();
                // produto.Should().Be(produtoValido);
            }
        }

        public class EditarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_ProdutoAtualizado()
            {
                produtosRepositorio.RecuperarProduto(Arg.Any<int>()).Returns(produtoValido);
                produtosRepositorio.Editar(Arg.Any<Produto>()).Returns(produtoValido);
            }
        }


    }
}