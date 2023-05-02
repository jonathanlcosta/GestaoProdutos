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

        public FornecedorResponse Editar(int id, FornecedorEditarRequest fornecedorEditarRequest)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var fornecedor = fornecedoresServico.Editar(id, 
                                    fornecedorEditarRequest.Descricao, 
                                 fornecedorEditarRequest.Cnpj);
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
                var fornecedor = fornecedoresServico.Validar(id);
                fornecedoresRepositorio.Excluir(fornecedor);
               unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public FornecedorResponse Inserir(FornecedorInserirRequest fornecedorInserirRequest)
        {
            var fornecedor = fornecedoresServico.Instanciar(fornecedorInserirRequest.Descricao, fornecedorInserirRequest.Cnpj);
            try
            {
                unitOfWork.BeginTransaction();
                fornecedor = fornecedoresServico.Inserir(fornecedor);
                unitOfWork.Commit();
                return mapper.Map<FornecedorResponse>(fornecedor);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<FornecedorResponse> Listar(int? pagina, int quantidade, FornecedorListarRequest fornecedorListarRequest)
        {
             if (pagina.Value <= 0) throw new Exception("Pagina não especificada");

            IQueryable<Fornecedor> query = fornecedoresRepositorio.Query();
            if (fornecedorListarRequest is null)
                throw new Exception();

            if (!string.IsNullOrEmpty(fornecedorListarRequest.Descricao))
                query = query.Where(p => p.Descricao.Contains(fornecedorListarRequest.Descricao));
             if (!string.IsNullOrEmpty(fornecedorListarRequest.Cnpj) && fornecedorListarRequest.Cnpj.Length != 14 )
                query = query.Where(p => p.Cnpj.Contains(fornecedorListarRequest.Cnpj));
            PaginacaoConsulta<Fornecedor> fornecedores = fornecedoresRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<FornecedorResponse> response;
            response = mapper.Map<PaginacaoConsulta<FornecedorResponse>>(fornecedores);
            return response;
        }

        public FornecedorResponse Recuperar(int id)
        {
            var fornecedor = fornecedoresServico.Validar(id);
            var response = mapper.Map<FornecedorResponse>(fornecedor);
            return response;
        }
    }
}