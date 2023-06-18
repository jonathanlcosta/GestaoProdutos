using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet("{codigo}")]
        public ActionResult<ProdutoResponse> Recuperar(int codigo)
        {
            var response = produtosAppServico.Recuperar(codigo);

            if (response == null)
                return NotFound();

            return Ok(response);
        }

       [HttpGet]
        public ActionResult<PaginacaoConsulta<ProdutoResponse>> Listar([FromQuery] ProdutoListarRequest request)
        {    var response = produtosAppServico.Listar(request);
            return Ok(response);
        }

        [HttpPost]
        public ActionResult<ProdutoResponse> Inserir([FromBody] ProdutoInserirRequest produto)
        {
            var retorno = produtosAppServico.Inserir(produto);
            return Ok(retorno);
        }

        [HttpPut("{codigo}")]
        public ActionResult Editar(int codigo, [FromBody] ProdutoEditarRequest produto)
        {

            produtosAppServico.Editar(codigo, produto);
            return Ok();
        }

        [HttpDelete]
        [Route("{codigo}")]
        public ActionResult Excluir(int codigo)
        {
            produtosAppServico.Excluir(codigo);
            return Ok();
        }
    }
}