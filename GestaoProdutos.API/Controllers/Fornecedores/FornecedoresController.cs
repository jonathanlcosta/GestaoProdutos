using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public ActionResult<FornecedorResponse> Recuperar(int id)
        {
            var response = fornecedoresAppServico.Recuperar(id);

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
        public ActionResult<PaginacaoConsulta<FornecedorResponse>> Listar([FromQuery] FornecedorListarRequest request)
        {    var response = fornecedoresAppServico.Listar(request);
            return Ok(response);
        }

                /// <summary>
    /// Insere fornecedor
    /// </summary>
      /// <param name="fornecedor"></param>
    /// <returns></returns>
        [HttpPost]
        public ActionResult<FornecedorResponse> Inserir([FromBody] FornecedorInserirRequest fornecedor)
        {
            var retorno = fornecedoresAppServico.Inserir(fornecedor);
            return Ok(retorno);
        }

        /// <summary>
    /// Edita fornecedor por Id
    /// </summary>
       /// <param name="id"></param>
      /// <param name="fornecedor"></param>
    /// <returns></returns>
        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] FornecedorEditarRequest fornecedor)
        {

            fornecedoresAppServico.Editar(id, fornecedor);
            return Ok();
        }

                /// <summary>
    /// Deleta fornecedor por Id
    /// </summary>
       /// <param name="id"></param>
    /// <returns></returns>
        [HttpDelete]
        [Route("{id}")]
        public ActionResult Excluir(int id)
        {
            fornecedoresAppServico.Excluir(id);
            return Ok();
        }
    }
}