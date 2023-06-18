using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Util;
using NHibernate;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly IProdutosServico produtosServico;
        private readonly IMapper mapper;
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly IUnitOfWork unitOfWork;

        public ProdutosAppServico(IProdutosServico produtosServico, IMapper mapper, IProdutosRepositorio produtosRepositorio,
        IFornecedoresServico fornecedoresServico, IUnitOfWork unitOfWork)
        {
            this.produtosServico = produtosServico;
            this.mapper = mapper;
            this.produtosRepositorio = produtosRepositorio;
            this.fornecedoresServico = fornecedoresServico;
            this.unitOfWork = unitOfWork;
        }
        public ProdutoResponse Editar(int codigo, ProdutoEditarRequest request)
        {
             ProdutoComando comando = mapper.Map<ProdutoComando>(request);
            try
            {
                    unitOfWork.BeginTransaction();
                    Produto produto = produtosServico.Editar(codigo, comando);
                    unitOfWork.Commit();
                return mapper.Map<ProdutoResponse>(produto);;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public void Excluir(int codigo)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var produto = produtosServico.Validar(codigo);
                produtosRepositorio.Deletar(produto);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public ProdutoResponse Inserir(ProdutoInserirRequest request)
        {
             ProdutoComando comando = mapper.Map<ProdutoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Produto produto = produtosServico.Inserir(comando);
                unitOfWork.Commit();
                return mapper.Map<ProdutoResponse>(produto);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<ProdutoResponse> Listar(ProdutoListarRequest request)
        {
            ProdutoListarFiltro filtro = mapper.Map<ProdutoListarFiltro>(request);
            IQueryable<Produto> query = produtosRepositorio.Filtrar(filtro);

            PaginacaoConsulta<Produto> produtos = produtosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            PaginacaoConsulta<ProdutoResponse> response;
            response = mapper.Map<PaginacaoConsulta<ProdutoResponse>>(produtos);
            return response;
        }

        public ProdutoResponse Recuperar(int codigo)
        {
            Produto produto = produtosServico.Validar(codigo);
            return mapper.Map<ProdutoResponse>(produto);
        }
    }
}