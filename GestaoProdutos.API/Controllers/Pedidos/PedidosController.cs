using GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;
using GestaoProdutos.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Pedidos
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidosAppServico pedidosAppServico;

        public PedidosController(IPedidosAppServico pedidosAppServico)
        {
            this.pedidosAppServico = pedidosAppServico;
        }

         /// <summary>
    /// Listar pedidos por paginação
    /// </summary>
      /// <param name="request"></param>
    /// <returns></returns>
       [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<PedidoResponse>>> Listar([FromQuery] PedidoListarRequest request)
        {    var response = await pedidosAppServico.ListarAsync(request);
            return Ok(response);
        }

                        /// <summary>
    /// Insere Pedido
    /// </summary>
      /// <param name="request"></param>
    /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<PedidoResponse>> Inserir([FromBody] PedidoRequest request)
        {
            var retorno = await pedidosAppServico.InserirAsync(request);
            return Ok(retorno);
        }
    }
}