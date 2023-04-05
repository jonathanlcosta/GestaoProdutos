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

        [HttpGet("{id}")]
        public ActionResult<FornecedorResponse> Recuperar(int id)
        {
            var response = fornecedoresAppServico.Recuperar(id);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

       [HttpGet]
        public ActionResult<PaginacaoConsulta<FornecedorResponse>> Listar(int pagina, int quantidade, [FromQuery] FornecedorListarRequest fornecedorListarRequest)
        {    var response = fornecedoresAppServico.Listar(pagina, quantidade, fornecedorListarRequest);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<FornecedorResponse> Inserir([FromBody] FornecedorInserirRequest fornecedor)
        {
            var retorno = fornecedoresAppServico.Inserir(fornecedor);
            return Ok(retorno);
        }

        [HttpPut("{id}")]
        public ActionResult Editar(int id, [FromBody] FornecedorEditarRequest fornecedor)
        {

            fornecedoresAppServico.Editar(id, fornecedor);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public ActionResult Excluir(int id)
        {
            fornecedoresAppServico.Excluir(id);
            return Ok();
        }
    }
}