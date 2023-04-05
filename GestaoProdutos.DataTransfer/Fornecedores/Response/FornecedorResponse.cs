using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Fornecedores.Response
{
    public class FornecedorResponse
    {
        public int Id{ get; set;}
        public string? Descricao { get; set;}
        public string? Cnpj{ get; set;}
    }
}