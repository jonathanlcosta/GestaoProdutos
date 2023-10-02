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
using NSubstitute.ReturnsExtensions;
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
            public async Task Dado_FornecedorNaoEncontrado_Espero_RegraDeNegocioExcecao()
            {
                fornecedorRepositorio.RecuperarAsync(2).ReturnsNull();
                await sut.Invoking(x => x.ValidarAsync(2)).Should().ThrowAsync<RegraDeNegocioExcecao>();

            }

            [Fact]
            public async Task Dado_FornecedorEncontrado_Espero_SemExcecao()
            {
                fornecedorRepositorio.RecuperarAsync(2).Returns(fornecedorValido);
                
                 await sut.Invoking(x => x.ValidarAsync(2)).Should().NotThrowAsync();
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
            public async Task Dado_FornecedorValido_Espero_FornecedorInserido()
            {
                 FornecedorComando comando = Builder<FornecedorComando>.CreateNew()
                .With(x => x.Cnpj, "19876545632312").Build();
                Fornecedor resultado = await sut.InserirAsync(comando);
                
                fornecedorRepositorio.InserirAsync(resultado).Returns(fornecedorValido);

                resultado.Should().BeOfType<Fornecedor>();
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Cnpj.Should().Be(comando.Cnpj);

            }
        }

         public class EditarMetodo : FornecedoresServicoTestes
        {
            [Fact]
            public async Task Quando_MetodoForChamado_Espero_FornecedorAtualizado()
            {
                FornecedorComando comando = Builder<FornecedorComando>.CreateNew()
                .With(x => x.Cnpj, "19876545632312").Build();
                
                sut.ValidarAsync(1).Returns(fornecedorValido);
                Fornecedor resultado = await sut.EditarAsync(1, comando);

                fornecedorRepositorio.RecuperarAsync(1).Returns(fornecedorValido);
                fornecedorRepositorio.EditarAsync(resultado).Returns(fornecedorValido);

                resultado.Should().BeOfType<Fornecedor>();
                resultado.Descricao.Should().Be(comando.Descricao);
                resultado.Cnpj.Should().Be(comando.Cnpj);
              
            }
        }
    }
}