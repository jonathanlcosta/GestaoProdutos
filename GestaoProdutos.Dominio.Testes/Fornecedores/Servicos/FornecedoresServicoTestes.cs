using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzWare.NBuilder;
using FluentAssertions;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Servicos;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comando;
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
            public void Dado_FornecedorNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                fornecedorRepositorio.Recuperar(2).Returns(x => null);
                sut.Invoking(x => x.Validar(2)).Should().Throw<RegraDeNegocioExcecao>();

            }

            [Fact]
            public void Dado_FornecedorEncontrado_Espero_FornecedorValido()
            {
                fornecedorRepositorio.Recuperar(2).Returns(fornecedorValido);
                sut.Validar(2).Should().BeSameAs(fornecedorValido);
            }
        }

        public class InstanciarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_ParametrosParaCriarFornecedores_Espero_FornecedorInstanciado()
            {
            FornecedorComando comando = Builder<FornecedorComando>.CreateNew()
            .With(x => x.Cnpj, "19876545632312").Build();
            Fornecedor resultado = sut.Instanciar(comando);

            Assert.NotNull(resultado);
            Assert.Equal(comando.Descricao, resultado.Descricao);
            Assert.Equal(comando.Cnpj, resultado.Cnpj);
            }
        }
        public class InserirMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Dado_FornecedorValido_Espero_FornecedorInserido()
            {
                 FornecedorComando comando = Builder<FornecedorComando>.CreateNew()
                .With(x => x.Cnpj, "19876545632312").Build();
                Fornecedor resultado = sut.Inserir(comando);
                
                fornecedorRepositorio.Inserir(resultado).Returns(fornecedorValido);

                resultado.Should().BeOfType<Fornecedor>();
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Cnpj.Should().Be(comando.Cnpj);

            }
        }

         public class EditarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public void Quando_MetodoForChamado_Espero_FornecedorAtualizado()
            {
                FornecedorComando comando = Builder<FornecedorComando>.CreateNew()
                .With(x => x.Cnpj, "19876545632312").Build();
                
                sut.Validar(1).Returns(fornecedorValido);
                Fornecedor resultado = sut.Editar(1, comando);

                fornecedorRepositorio.Recuperar(1).Returns(fornecedorValido);
                fornecedorRepositorio.Editar(resultado).Returns(fornecedorValido);

                resultado.Should().BeOfType<Fornecedor>();
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Cnpj.Should().Be(comando.Cnpj);
              
            }
        }
    }
}