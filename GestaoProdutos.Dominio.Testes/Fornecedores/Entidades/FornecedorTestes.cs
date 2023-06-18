using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Fornecedores.Entidades
{
    public class FornecedorTestes
    {
        private readonly Fornecedor sut; 
        public FornecedorTestes()
        {
            sut = Builder<Fornecedor>.CreateNew().Build();
        }

        public class SetDescricaoMetodo: FornecedorTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_DescricaoNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecaoExcecao(string descricao)
            {
                sut.Invoking(x => x.SetDescricaoFornecedor(descricao)).Should().Throw<AtributoObrigatorioExcecao>();
            }
            [Fact]
            public void Dado_DescricaoValido_Espero_PropriedadesPreenchidas()
            {
                string descricao = "Fornecedor";
                sut.SetDescricaoFornecedor(descricao);
                sut.Descricao.Should().NotBeNullOrWhiteSpace(descricao);
                sut.Descricao.Should().Be(descricao);
            }
    }

    public class SetCnpjMetodo: FornecedorTestes
        {
            [Theory]
            [InlineData(null)]
            [InlineData("")]
            [InlineData("                ")]
            public void Dado_CnpjNuloOuEspacoEmBranco_Espero_AtributoObrigatorioExcecao(string cnpj)
            {
                sut.Invoking(x => x.SetCnpj(cnpj)).Should().Throw<AtributoObrigatorioExcecao>();
            }

            [Fact]
            public void Dado_CnpjComMaisDeQuatorzeCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetCnpj(new string('*', 15))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_CnpjComMenosDeQuatorzeCaracteres_Espero_TamanhoDeAtributoInvalidoExcecao()
            {
                sut.Invoking(x => x.SetCnpj(new string('*', 13))).Should().Throw<TamanhoDeAtributoInvalidoExcecao>();
            }

            [Fact]
            public void Dado_CnpjValido_Espero_PropriedadesPreenchidas()
            {
                string cnpj = "12345678911234";
                sut.SetCnpj(cnpj);
                sut.Cnpj.Should().NotBeNullOrWhiteSpace(cnpj);
                sut.Cnpj.Should().Be(cnpj);
            }
    }
    }
}