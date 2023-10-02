using GestaoProdutos.Aplicacao.Fornecedores.Servicos.Interfaces;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Util;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Fornecedores
{
    [ApiController]
    [Route("api/[controller]")]
    public class FornecedoresController : ControllerBase
    {
        private readonly IFornecedoresAppServico fornecedoresAppServico;

        public FornecedoresController(IFornecedoresAppServico fornecedoresAppServico)
        {
            this.fornecedoresAppServico = fornecedoresAppServico;
        }
                                 
    /// <summary>
    /// Recupera fornecedor por Id
    /// </summary>
      /// <param name="id"></param>
    /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FornecedorResponse>> Recuperar(int id)
        {
            var response = await fornecedoresAppServico.RecuperarAsync(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

        /// <summary>
    /// Lista fornecedores por paginação
    /// </summary>
      /// <param name="request"></param>
    /// <returns></returns>
       [HttpGet]
        public async Task<ActionResult<PaginacaoConsulta<FornecedorResponse>>> Listar([FromQuery] FornecedorListarRequest request)
        {    var response = await fornecedoresAppServico.ListarAsync(request);
            return Ok(response);
        }

                /// <summary>
    /// Insere fornecedor
    /// </summary>
      /// <param name="fornecedor"></param>
    /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FornecedorResponse>> Inserir([FromBody] FornecedorInserirRequest fornecedor)
        {
            var retorno = await fornecedoresAppServico.InserirAsync(fornecedor);
            return Ok(retorno);
        }

        /// <summary>
    /// Edita fornecedor por Id
    /// </summary>
       /// <param name="id"></param>
      /// <param name="fornecedor"></param>
    /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult> Editar(int id, [FromBody] FornecedorEditarRequest fornecedor)
        {
            await fornecedoresAppServico.EditarAsync(id, fornecedor);
            return Ok();
        }

                /// <summary>
    /// Deleta fornecedor por Id
    /// </summary>
       /// <param name="id"></param>
    /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult> Excluir(int id)
        {
            await fornecedoresAppServico.ExcluirAsync(id);
            return Ok();
        }
    }
}