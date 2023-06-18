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

        public FornecedorResponse Editar(int id, FornecedorEditarRequest request)
        {
            FornecedorComando comando = mapper.Map<FornecedorComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = fornecedoresServico.Editar(id, comando);          
                unitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public void Excluir(int id)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = fornecedoresServico.Validar(id);
                fornecedoresRepositorio.Excluir(fornecedor);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public FornecedorResponse Inserir(FornecedorInserirRequest request)
        {
          FornecedorComando comando = mapper.Map<FornecedorComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Fornecedor fornecedor = fornecedoresServico.Inserir(comando);
                unitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<FornecedorResponse> Listar(FornecedorListarRequest request)
        {
            FornecedorListarFiltro filtro = mapper.Map<FornecedorListarFiltro>(request);
            IQueryable<Fornecedor> query = fornecedoresRepositorio.Filtrar(filtro);

            PaginacaoConsulta<Fornecedor> fornecedores = fornecedoresRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);
            PaginacaoConsulta<FornecedorResponse> response;
            response = mapper.Map<PaginacaoConsulta<FornecedorResponse>>(fornecedores);
            return response;
        }

        public FornecedorResponse Recuperar(int id)
        {
            Fornecedor fornecedor = fornecedoresServico.Validar(id);
            return mapper.Map<FornecedorResponse>(fornecedor);
        }
    }
}