using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comando;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Util;
using NHibernate;

namespace GestaoProdutos.Aplicacao.Fornecedores.Servicos
{
    public class FornecedoresAppServico : IFornecedoresAppServico
    {
        private readonly IFornecedoresServico fornecedoresServico;
        private readonly IMapper mapper;
        private readonly IFornecedoresRepositorio fornecedoresRepositorio;
        private readonly IUnitOfWork unitOfWork;

        public FornecedoresAppServico(IFornecedoresServico fornecedoresServico,IMapper mapper, 
        IFornecedoresRepositorio fornecedoresRepositorio, IUnitOfWork unitOfWork)
        {
            this.fornecedoresServico = fornecedoresServico;
            this.fornecedoresRepositorio = fornecedoresRepositorio;
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        public async Task<FornecedorResponse> EditarAsync(int id, FornecedorEditarRequest request)
        {
            FornecedorComando comando = mapper.Map<FornecedorComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = await fornecedoresServico.EditarAsync(id, comando);          
                unitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task ExcluirAsync(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = await fornecedoresServico.ValidarAsync(id);
                await fornecedoresRepositorio.ExcluirAsync(fornecedor);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<FornecedorResponse> InserirAsync(FornecedorInserirRequest request)
        {
          FornecedorComando comando = mapper.Map<FornecedorComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = await fornecedoresServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<PaginacaoConsulta<FornecedorResponse>> ListarAsync(FornecedorListarRequest request)
        {
            FornecedorListarFiltro filtro = mapper.Map<FornecedorListarFiltro>(request);
            IQueryable<Fornecedor> query = await fornecedoresRepositorio.FiltrarAsync(filtro);

            PaginacaoConsulta<Fornecedor> fornecedores = fornecedoresRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
           return mapper.Map<PaginacaoConsulta<FornecedorResponse>>(fornecedores);
        }

        public async Task<FornecedorResponse> RecuperarAsync(int id)
        {
            Fornecedor fornecedor = await fornecedoresServico.ValidarAsync(id);
            return mapper.Map<FornecedorResponse>(fornecedor);
        }
    }
}