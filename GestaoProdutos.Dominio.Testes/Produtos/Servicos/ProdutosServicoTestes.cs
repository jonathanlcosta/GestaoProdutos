using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
using NSubstitute;
using NSubstitute.ReturnsExtensions;
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
            public void Dado_ProdutoNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                produtosRepositorio.RecuperarProdutoAsync(2).ReturnsNull();
                sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();

            }

            [Fact]
            public void Dado_ProdutoEncontrado_Espero_ProdutoValido()
            {
                produtosRepositorio.RecuperarProdutoAsync(2).Returns(produtoValido);
                sut.ValidarAsync(2).Should().BeSameAs(produtoValido);
            }
        }

        public class InstanciarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public async Task Dado_ParametrosParaCriarProdutos_Espero_ProdutoInstanciado()
            {
            DateTime dataFabricacao = new DateTime(2023, 4, 1);
            DateTime dataValidade = new DateTime(2023, 5, 1);

            ProdutoComando comando = Builder<ProdutoComando>.CreateNew().With(x => x.DataFabricacao, dataFabricacao)
            .With(x => x.DataValidade, dataValidade).Build();

            Produto resultado = await sut.InstanciarAsync(comando);

            Assert.NotNull(resultado);
            Assert.Equal(comando.Descricao, resultado.Descricao);
            Assert.Equal(dataFabricacao, resultado.DataFabricacao);
            Assert.Equal(dataValidade, resultado.DataValidade);
            }
        }

        public class InserirMetodo : ProdutosServicoTestes
        {
            [Fact]
            public async Task Dado_ProdutoValido_Espero_ProdutoInserido()
            {
                 DateTime dataFabricacao = new DateTime(2023, 4, 1);
                 DateTime dataValidade = new DateTime(2023, 5, 1);
                ProdutoComando comando = Builder<ProdutoComando>.CreateNew().With(x => x.DataFabricacao, dataFabricacao)
                .With(x => x.DataValidade, dataValidade).Build();

                Produto resultado = await sut.InserirAsync(comando);
                produtosRepositorio.InserirAsync(resultado).Returns(produtoValido);

                resultado.Should().BeOfType<Produto>();
                resultado.DataFabricacao.Should().Be(comando.DataFabricacao);
                resultado.DataValidade.Should().Be(comando.DataValidade);
            }
        }

        public class EditarMetodo : ProdutosServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_ProdutoAtualizado()
            {
                produtosRepositorio.RecuperarProdutoAsync(1).Returns(produtoValido);

                DateTime dataFabricacao = new DateTime(2023, 4, 1);
                 DateTime dataValidade = new DateTime(2023, 5, 1);
                ProdutoComando comando = Builder<ProdutoComando>.CreateNew().With(x => x.DataFabricacao, dataFabricacao)
                .With(x => x.DataValidade, dataValidade).Build();

                sut.ValidarAsync(1).Returns(produtoValido);
                Produto resultado = await sut.EditarAsync(1, comando);
                produtosRepositorio.EditarAsync(resultado).Returns(produtoValido);
                fornecedoresServico.ValidarAsync(comando.IdFornecedor).Returns(fornecedorValido);

                resultado.DataFabricacao.Should().Be(comando.DataFabricacao);
                resultado.DataValidade.Should().Be(comando.DataValidade);
            }
        }


    }
}