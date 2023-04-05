using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Fornecedores.Request
{
    public class FornecedorEditarRequest
    {
        public string? Descricao { get; set;}
        public string? Cnpj{ get; set;}
    }
}