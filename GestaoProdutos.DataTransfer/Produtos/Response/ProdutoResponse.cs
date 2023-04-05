using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Fornecedores.Response;

namespace GestaoProdutos.DataTransfer.Produtos.Response
{
    public class ProdutoResponse
    {
        public int Codigo {get; set;}
        public string? Descricao {get; set;}
        public DateTime? DataFabricacao {get;set;}
        public DateTime DataValidade {get;set;}
        public FornecedorResponse? Fornecedor {get; set;}
    }
}