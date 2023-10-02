using GestaoProdutos.Aplicacao.Produtos.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Produtos.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutosAppServico produtosAppServico;

        public ProdutosController(IProdutosAppServico produtosAppServico)
        {
            this.produtosAppServico = produtosAppServico;
        }

                         /// <summary>
    /// Recupera produto por Código
    /// </summary>
      /// <param name="codigo"></param>
    /// <returns></returns>
        [HttpGet("{codigo}")]
        public async Task<ActionResult<ProdutoResponse>> Recuperar(int codigo)
        {
            var response = await produtosAppServico.RecuperarAsync(codigo);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

                 /// <summary>
    /// Listar produtos por paginação
    /// </summary>
      /// <param name="request"></param>
    /// <returns></returns>
       [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<ProdutoResponse>>> Listar([FromQuery] ProdutoListarRequest request)
        {    var response = await produtosAppServico.ListarAsync(request);
            return Ok(response);
        }

                        /// <summary>
    /// Insere produto
    /// </summary>
      /// <param name="produto"></param>
    /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ProdutoResponse>> Inserir([FromBody] ProdutoInserirRequest produto)
        {
            var retorno = await produtosAppServico.InserirAsync(produto);
            return Ok(retorno);
        }

             /// <summary>
    /// Edita um produto por Código
    /// </summary>
    /// <param name="codigo"></param>
      /// <param name="produto"></param>
    /// <returns></returns>
        [HttpPut("{codigo}")]
        public async Task<ActionResult> Editar(int codigo, [FromBody] ProdutoEditarRequest produto)
        {

           await produtosAppServico.EditarAsync(codigo, produto);
            return Ok();
        }

        /// <summary>
    /// Deleta um produto por Código
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
        [HttpDelete]
        [Route("{codigo}")]
        public async Task<ActionResult> Excluir(int codigo)
        {
            await produtosAppServico.ExcluirAsync(codigo);
            return Ok();
        }
    }
}