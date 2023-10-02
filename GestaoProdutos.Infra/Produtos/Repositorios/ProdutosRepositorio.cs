using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Infra.Genericos;
using NHibernate;
using NHibernate.Linq;

namespace GestaoProdutos.Infra.Produtos
{
    public class ProdutosRepositorio : GenericoRepositorio<Produto>, IProdutosRepositorio
    {
        public ProdutosRepositorio(ISession session) : base(session)
        {
            
        }

        public async Task DeletarAsync(Produto produto)
        {
            produto.SetSituacao(SituacaoProdutoEnum.Inativo);
            await session.UpdateAsync(produto);
        }

        public async Task<IQueryable<Produto>> FiltrarAsync(ProdutoListarFiltro filtro)
        {
           IQueryable<Produto> query = await QueryAsync();
           query.Where(x=>x.Situacao != SituacaoProdutoEnum.Inativo);

            if (!string.IsNullOrWhiteSpace(filtro.Descricao))
            {
                 query = query.Where(p => p.Descricao.Contains(filtro.Descricao));
            }

            if(filtro.Codigo != 0)
            {
                query = query.Where(x => x.Codigo == filtro.Codigo);
            }

             if(filtro.IdFornecedor != 0)
            {
                query = query.Where(x => x.Fornecedor.Id == filtro.IdFornecedor);
            }

            if(filtro.DataFabricacao != DateTime.MinValue)
            {
                query = query.Where(x => x.DataFabricacao == filtro.DataFabricacao);
            }

            if(filtro.DataValidade != DateTime.MinValue)
            {
                query = query.Where(x => x.DataValidade == filtro.DataValidade);
            }

            return query;
        }

        public async Task<Produto> RecuperarProdutoAsync(int codigo)
        {
            var produto = await Query()
            .Where(x => x.Codigo == codigo && x.Situacao != SituacaoProdutoEnum.Inativo)
            .FirstOrDefaultAsync();
            return produto;
        }


    }
}