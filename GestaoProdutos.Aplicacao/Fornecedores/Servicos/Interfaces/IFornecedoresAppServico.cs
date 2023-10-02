using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces
{
    public interface IFornecedoresAppServico
    {
        Task<PaginacaoConsulta<FornecedorResponse>> ListarAsync(FornecedorListarRequest request);
        Task<FornecedorResponse> RecuperarAsync(int id);
        Task<FornecedorResponse> InserirAsync(FornecedorInserirRequest request);
        Task<FornecedorResponse> EditarAsync(int id, FornecedorEditarRequest request);
        Task ExcluirAsync(int id);
    }
}