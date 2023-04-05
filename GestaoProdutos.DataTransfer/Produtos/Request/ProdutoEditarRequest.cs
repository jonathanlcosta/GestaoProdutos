using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Produtos.Request
{
    public class ProdutoEditarRequest
    {
        
        public string? Descricao {get; set;}
        public DateTime DataFabricacao {get;set;}
        public DateTime DataValidade {get;set;}
        public int IdFornecedor {get; set;}
    }
}