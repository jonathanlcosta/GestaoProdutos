using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;
using GestaoProdutos.Dominio.Produtos.Repositorios;
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
            session.Flush();
        }

         public IQueryable<Produto> QueryProduto()
        {
            return session.Query<Produto>().Where(x=>x.Situacao != SituacaoProdutoEnum.Inativo);
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