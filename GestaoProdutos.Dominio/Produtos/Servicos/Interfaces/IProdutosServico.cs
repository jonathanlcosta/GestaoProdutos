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
        Produto Validar(int codigo);
        Produto Inserir(ProdutoComando comando);
        Produto Instanciar(ProdutoComando comando);
        Produto Editar(int codigo, ProdutoComando comando);
    }
}