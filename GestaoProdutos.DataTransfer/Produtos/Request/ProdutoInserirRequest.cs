using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Produtos.Request
{
    public record ProdutoInserirRequest(string Descricao, DateTime DataFabricacao, DateTime DataValidade, int IdFornecedor);
}