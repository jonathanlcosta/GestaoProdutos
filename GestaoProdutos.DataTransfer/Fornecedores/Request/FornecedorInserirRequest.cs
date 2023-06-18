using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Fornecedores.Request
{
    public record FornecedorInserirRequest(string Descricao, string Cnpj);
}