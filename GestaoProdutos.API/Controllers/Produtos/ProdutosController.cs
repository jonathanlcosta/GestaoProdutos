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
        public ActionResult<ProdutoResponse> Recuperar(int codigo)
        {
            var response = produtosAppServico.Recuperar(codigo);

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
        public ActionResult<PaginacaoConsulta<ProdutoResponse>> Listar([FromQuery] ProdutoListarRequest request)
        {    var response = produtosAppServico.Listar(request);
            return Ok(response);
        }

                        /// <summary>
    /// Insere produto
    /// </summary>
      /// <param name="produto"></param>
    /// <returns></returns>
        [HttpPost]
        public ActionResult<ProdutoResponse> Inserir([FromBody] ProdutoInserirRequest produto)
        {
            var retorno = produtosAppServico.Inserir(produto);
            return Ok(retorno);
        }

             /// <summary>
    /// Edita um produto por Código
    /// </summary>
    /// <param name="codigo"></param>
      /// <param name="produto"></param>
    /// <returns></returns>
        [HttpPut("{codigo}")]
        public ActionResult Editar(int codigo, [FromBody] ProdutoEditarRequest produto)
        {

            produtosAppServico.Editar(codigo, produto);
            return Ok();
        }

        /// <summary>
    /// Deleta um produto por Código
    /// </summary>
    /// <param name="codigo"></param>
    /// <returns></returns>
        [HttpDelete]
        [Route("{codigo}")]
        public ActionResult Excluir(int codigo)
        {
            produtosAppServico.Excluir(codigo);
            return Ok();
        }
    }
}