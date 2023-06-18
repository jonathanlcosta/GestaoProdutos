using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Repositorios;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Produtos
{
    public class ProdutosRepositorio : GenericoRepositorio<Produto>, IProdutosRepositorio
    {
        public ProdutosRepositorio(ISession session) : base(session)
        {
            
        }

        public void Deletar(Produto produto)
        {
            produto.SetSituacao(SituacaoProdutoEnum.Inativo);
            session.Update(produto);
        }

        public IQueryable<Produto> Filtrar(ProdutoListarFiltro filtro)
        {
           IQueryable<Produto> query = Query().Where(x=>x.Situacao != SituacaoProdutoEnum.Inativo);

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

        public Produto RecuperarProduto(int codigo)
        {
            var produto = session.Query<Produto>()
            .Where(x => x.Codigo == codigo && x.Situacao != SituacaoProdutoEnum.Inativo)
            .FirstOrDefault();
            return produto;
        }


    }
}