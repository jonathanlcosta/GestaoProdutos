using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces
{
    public interface IPedidosAppServico
    {
        Task<PaginacaoConsulta<PedidoResponse>> ListarAsync(PedidoListarRequest request);
        Task<PedidoResponse> RecuperarAsync(int codigo);
        Task<PedidoResponse> InserirAsync(PedidoRequest request);
    }
}