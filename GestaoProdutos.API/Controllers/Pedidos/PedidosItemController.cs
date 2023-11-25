using GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Pedidos.Request;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Pedidos
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosItemController : ControllerBase
    {
        private readonly IPedidosItemAppServico pedidosItemAppServico;

        public PedidosItemController(IPedidosItemAppServico pedidosItemAppServico)
        {
            this.pedidosItemAppServico = pedidosItemAppServico;
        }

         /// <summary>
    /// Altera um item do pedido por codigo
    /// </summary>
    /// <param name="codigo"></param>
      /// <param name="request"></param>
    /// <returns></returns>
        [HttpPut("{codigo}")]
        public async Task<ActionResult> AlterarSituacaoItem(int codigo, [FromBody] AlterarSituacaoItemRequest request)
        {
           var pedidoItem = await pedidosItemAppServico.AlterarSituacaoPedidoItem(codigo, request);
            return Ok(pedidoItem);
        }
    }
}