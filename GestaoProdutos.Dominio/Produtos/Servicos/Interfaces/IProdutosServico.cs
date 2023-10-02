using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        Task<Produto> ValidarAsync(int codigo);
        Task<Produto> InserirAsync(ProdutoComando comando);
        Task<Produto> InstanciarAsync(ProdutoComando comando);
        Task<Produto> EditarAsync(int codigo, ProdutoComando comando);
    }
}