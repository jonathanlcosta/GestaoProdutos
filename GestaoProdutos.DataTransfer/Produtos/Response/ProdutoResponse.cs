using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Fornecedores.Response;

namespace GestaoProdutos.DataTransfer.Produtos.Response
{
   public record ProdutoResponse(int Codigo, string Descricao, DateTime DataFabricacao, DateTime DataValidade, FornecedorResponse Fornecedor);
}