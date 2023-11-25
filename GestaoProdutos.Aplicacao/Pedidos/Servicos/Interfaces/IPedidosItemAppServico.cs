using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;

namespace GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces
{
    public interface IPedidosItemAppServico
    {
        Task<PedidoItemResponse> AlterarSituacaoPedidoItem(int codigoItem, AlterarSituacaoItemRequest request);
    }
}