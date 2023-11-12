using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces
{
    public interface IProdutosAppServico
    {
        Task<PaginacaoConsulta<ProdutoResponse>> ListarAsync(ProdutoListarRequest request);
        Task<ProdutoResponse> RecuperarAsync(int codigo);
        Task<ProdutoResponse> InserirAsync(ProdutoInserirRequest request);
        Task<ProdutoResponse> EditarAsync(int codigo, ProdutoEditarRequest request);
        Task ExcluirAsync(int codigo);
        IEnumerable<ProdutoResponse> RecuperarPorFornecedor(int idFornecedor);
    }
}