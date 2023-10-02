using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Genericos;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Produtos.Repositorios
{
    public interface IProdutosRepositorio : IGenericoRepositorio<Produto>
    {
        public Task DeletarAsync(Produto produto);
        public Task<Produto> RecuperarProdutoAsync(int id);
        Task<IQueryable<Produto>> FiltrarAsync(ProdutoListarFiltro filtro);
    }
}