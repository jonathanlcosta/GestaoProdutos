using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Servicos;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using NSubstitute;
using Xunit;

namespace GestaoProdutos.Dominio.Testes.Fornecedores.Servicos
{
    public class FornecedoresServicoTestes
    {
        private readonly IFornecedoresServico sut;
        private readonly Fornecedor fornecedorValido;
        private readonly IFornecedoresRepositorio fornecedorRepositorio;

        public FornecedoresServicoTestes()
        {
            fornecedorValido = Builder<Fornecedor>.CreateNew().Build();
            fornecedorRepositorio = Substitute.For<IFornecedoresRepositorio>();
            sut = new FornecedoresServico(fornecedorRepositorio);
        }

        public class ValidarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_FornecedorNaoEncontrado_Espero_Excecao()
            {
                fornecedorRepositorio.Recuperar(Arg.Any<int>()).Returns(x => null);
                sut.Invoking(x => x.Validar(2)).Should().Throw<Exception>();

            }

            [Fact]
            public void Dado_FornecedorEncontrado_Espero_FornecedorValido()
            {
                fornecedorRepositorio.Recuperar(Arg.Any<int>()).Returns(fornecedorValido);
                sut.Validar(2).Should().BeSameAs(fornecedorValido);
            }
        }

        public class InstanciarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarFornecedores_Espero_FornecedorInstanciado()
            {

            var fornecedor = sut.Instanciar("Fornecedor", "12345678912345");

            Assert.NotNull(fornecedor);
            Assert.Equal("Fornecedor", fornecedor.Descricao);
            Assert.Equal("12345678912345", fornecedor.Cnpj);
            }
        }
        public class InserirMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_FornecedorValido_Espero_FornecedorInserido()
            {
                fornecedorRepositorio.Inserir(Arg.Any<Fornecedor>()).Returns(fornecedorValido);

                var fornecedor = sut.Inserir(fornecedorValido);

                fornecedorRepositorio.Received(1).Inserir(fornecedorValido);
                fornecedor.Should().BeOfType<Fornecedor>();
                fornecedor.Should().Be(fornecedorValido);
            }
        }

         public class EditarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_FornecedorAtualizado()
            {
                string cnpj = "12345678912345";
                fornecedorRepositorio.Recuperar(1).Returns(fornecedorValido);
                sut.Editar(1, "Fornecedor", cnpj);
                fornecedorValido.Id.Should().Be(1);
                fornecedorValido.Descricao.Should().Be("Fornecedor");
                fornecedorValido.Cnpj.Should().Be(cnpj);
                fornecedorRepositorio.Received().Editar(fornecedorValido);
            }
        }
    }
}