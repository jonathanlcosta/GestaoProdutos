using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Entidades;
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
        public async Task<ProdutoResponse> EditarAsync(int codigo, ProdutoEditarRequest request)
        {
             ProdutoComando comando = mapper.Map<ProdutoComando>(request);
            try
            {
                    unitOfWork.BeginTransaction();
                    Produto produto = await produtosServico.EditarAsync(codigo, comando);
                    unitOfWork.Commit();
                return mapper.Map<ProdutoResponse>(produto);;
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task ExcluirAsync(int codigo)
        {
            try
            {
                unitOfWork.BeginTransaction();
                var produto = await produtosServico.ValidarAsync(codigo);
                await produtosRepositorio.DeletarAsync(produto);
                unitOfWork.Commit();
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<ProdutoResponse> InserirAsync(ProdutoInserirRequest request)
        {
             ProdutoComando comando = mapper.Map<ProdutoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Produto produto = await produtosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<ProdutoResponse>(produto);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<PaginacaoConsulta<ProdutoResponse>> ListarAsync(ProdutoListarRequest request)
        {
            ProdutoListarFiltro filtro = mapper.Map<ProdutoListarFiltro>(request);
            IQueryable<Produto> query = await produtosRepositorio.FiltrarAsync(filtro);

            PaginacaoConsulta<Produto> produtos = produtosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            return mapper.Map<PaginacaoConsulta<ProdutoResponse>>(produtos);
        }

        public async Task<ProdutoResponse> RecuperarAsync(int codigo)
        {
            Produto produto = await produtosServico.ValidarAsync(codigo);
            return mapper.Map<ProdutoResponse>(produto);
        }
    }
}