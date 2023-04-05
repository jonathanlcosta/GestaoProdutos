using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Genericos;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio : IGenericoRepositorio<Produto>
    {
        public void Deletar(Produto produto);
        public Produto RecuperarProduto(int id);
         public IQueryable<Produto> QueryProduto();
    }
}