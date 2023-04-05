using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Dominio.Produtos.Servicos.Interfaces
{
    public interface IProdutosServico
    {
        Produto Validar(int codigo);
        Produto Inserir(Produto produto);
        Produto Instanciar(string descricao, DateTime dataFabricacao, DateTime dataValidade, int idFornecedor);
        Produto Editar(int codigo, string descricao, DateTime dataFabricacao, DateTime dataValidade, int idFornecedor);
    }
}