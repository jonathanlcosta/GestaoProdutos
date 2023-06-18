using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Fornecedores.Response
{
    public record FornecedorResponse(int Id, string Descricao, string Cnpj);
}