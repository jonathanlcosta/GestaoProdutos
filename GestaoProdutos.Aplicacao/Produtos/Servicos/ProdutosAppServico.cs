using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Util;
using NHibernate;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos
{
    public class ProdutosAppServico : IProdutosAppServico
    {
        private readonly IProdutosServico produtosServico;
        private readonly IMapper mapper;
        private readonly ISession session;
        private readonly IProdutosRepositorio produtosRepositorio;
        private readonly IFornecedoresServico fornecedoresServico;

        public ProdutosAppServico(IProdutosServico produtosServico, IMapper mapper, ISession session, IProdutosRepositorio produtosRepositorio,
        IFornecedoresServico fornecedoresServico)
        {
            this.produtosServico = produtosServico;
            this.mapper = mapper;
            this.session = session;
            this.produtosRepositorio = produtosRepositorio;
            this.fornecedoresServico = fornecedoresServico;
        }
        public ProdutoResponse Editar(int codigo, ProdutoEditarRequest produtoEditarRequest)
        {
          var produto = mapper.Map<Produto>(produtoEditarRequest);
            produto = produtosServico.Editar(codigo, 
                                    produtoEditarRequest.Descricao, 
                                    produtoEditarRequest.DataFabricacao, 
                                    produtoEditarRequest.DataValidade, 
                                    produtoEditarRequest.IdFornecedor);
            var transacao = session.BeginTransaction();
            try
            {
                produto = produtosRepositorio.Editar(produto);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<ProdutoResponse>(produto);;
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public void Excluir(int codigo)
        {
            var transacao = session.BeginTransaction();
            try
            {
                var produto = produtosServico.Validar(codigo);
                produtosRepositorio.Deletar(produto);
                if(transacao.IsActive)
                    transacao.Commit();
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public ProdutoResponse Inserir(ProdutoInserirRequest produtoInserirRequest)
        {

            var produto = produtosServico.Instanciar(
                produtoInserirRequest.Descricao, 
                                    produtoInserirRequest.DataFabricacao, 
                                    produtoInserirRequest.DataValidade, 
                                    produtoInserirRequest.IdFornecedor);
            var transacao = session.BeginTransaction();
            try
            {
                produto = produtosRepositorio.Inserir(produto);
                if(transacao.IsActive)
                    transacao.Commit();
                return mapper.Map<ProdutoResponse>(produto);
            }
            catch
            {
                if(transacao.IsActive)
                    transacao.Rollback();
                throw;
            }
        }

        public PaginacaoConsulta<ProdutoResponse> Listar(int? pagina, int quantidade, ProdutoListarRequest produtoListarRequest)
        {
            if (pagina.Value <= 0) throw new Exception("Pagina não especificada");

            IQueryable<Produto> query = produtosRepositorio.QueryProduto().Where(p => p.Situacao != SituacaoProdutoEnum.Inativo);
            if (produtoListarRequest is null)
                throw new Exception();

            if (!string.IsNullOrEmpty(produtoListarRequest.Descricao))
                query = query.Where(p => p.Descricao.Contains(produtoListarRequest.Descricao));

            if ((produtoListarRequest.DataValidade != DateTime.MinValue))
                query = query.Where(p => p.DataValidade.Date == produtoListarRequest.DataValidade.Date);
            if ((produtoListarRequest.DataFabricacao != DateTime.MinValue))
                query = query.Where(p => p.DataFabricacao.Date == produtoListarRequest.DataFabricacao.Date);

          if (produtoListarRequest.IdFornecedor.HasValue && produtoListarRequest.IdFornecedor.Value != 0)
            {
                query = query.Where(x => x.Fornecedor!.Id == produtoListarRequest.IdFornecedor.Value);
            }

            PaginacaoConsulta<Produto> produtos = produtosRepositorio.Listar(query, pagina, quantidade);
            PaginacaoConsulta<ProdutoResponse> response;
            response = mapper.Map<PaginacaoConsulta<ProdutoResponse>>(produtos);
            return response;
        }

        public ProdutoResponse Recuperar(int codigo)
        {
           var produto = produtosServico.Validar(codigo);
            var response = mapper.Map<ProdutoResponse>(produto);
            return response;
        }
    }
}