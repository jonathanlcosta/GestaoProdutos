using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Produtos.Entidades;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Produtos.Entidades
{
    public class ProdutoTestes
    {
        private readonly Produto sut; 
        private readonly Fornecedor fornecedorValido;
        public ProdutoTestes()
        {
            sut = Builder<Produto>.CreateNew().Build();
            fornecedorValido = Builder<Fornecedor>.CreateNew().Build();
        }

        public class SetDescricaoMetodo: ProdutoTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string descricao)
            {
                sut.Invoking(x => x.SetDescProduto(descricao)).Should().Throw<AtributoObrigatorioExcecao>();
            }
            [Fact]
            public void Dado_DescricaoValido_Espero_PropriedadesPreenchidas()
            {
                string descricao = "Parabrisa";
                sut.SetDescProduto(descricao);
                sut.Descricao.Should().NotBeNullOrWhiteSpace(descricao);
                sut.Descricao.Should().Be(descricao);
            }
    }

    public class SetDataFabricacao : ProdutoTestes
    {
        [Fact]
        public void Dado_DataFabricacaoComValorMinimo_Espero_AtributoObrigatorioExcecao()
        {
            DateTime data = DateTime.MinValue;
            sut.Invoking(x => x.SetDataFabricacao(data)).Should().Throw<AtributoObrigatorioExcecao>();
        }

         [Fact]
    public void SetDataFabricacao_DeveLancarExcecao_Quando_DataFabricacaoInvalida()
    {
        var data = new DateTime(2022, 12, 31);
        sut.SetDataValidade(data);
        Assert.Throws<RegraDeNegocioExcecao>(() => sut.SetDataFabricacao(new DateTime(2023, 1, 1)));
    }

    [Fact]
    public void SetDataFabricacao_DeveAtualizarDataFabricacao()
    {
        DateTime dataFabricacao = new DateTime(2023, 3, 1);
        sut.SetDataFabricacao(dataFabricacao);
        Assert.Equal(dataFabricacao, sut.DataFabricacao);
    }

    }

     public class SetDataValidade : ProdutoTestes
    {
        [Fact]
        public void Dado_DataValidadeComValorMinimo_Espero_AtributoObrigatorioExcecao()
        {
            DateTime data = DateTime.MinValue;
            sut.Invoking(x => x.SetDataValidade(data)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_DataDeValidadeValida_Espero_PropriedadesPreenchidas()
        {
            
            DateTime data = new DateTime(2022, 2, 12);
             sut.SetDataValidade(data);
                sut.DataValidade.Should().Be(data);
        }

    }

    public class SetFornecedor : ProdutoTestes
    {
        [Fact]
        public void Dado_FornecedorNulo_Espero_AtributoObrigatorioExcecao()
        {
            Fornecedor fornecedor = null;
            sut.Invoking(x => x.SetFornecedor(fornecedor)).Should().Throw<AtributoObrigatorioExcecao>();
        }

        [Fact]
        public void Dado_FornecedorValido_EsperoPropriedadesPreenchidas()
        {
            sut.SetFornecedor(fornecedorValido);
            sut.Fornecedor.Should().Be(fornecedorValido);
        }
    }
    }
}