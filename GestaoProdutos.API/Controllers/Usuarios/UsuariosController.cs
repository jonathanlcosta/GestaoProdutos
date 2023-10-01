using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Aplicacao.Autenticacoes.Comandos;
using GestaoProdutos.DataTransfer.Usuarios.Request;
using GestaoProdutos.DataTransfer.Usuarios.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GestaoProdutos.API.Controllers.Usuarios
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
         private readonly IMediator mediator;

        public UsuariosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioResponse>> Inserir([FromBody] UsuarioInserirRequest request)
        {
            UsuarioResponse retorno = await mediator.Send(request);
            return Ok(retorno);
        }

         [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginComando comando)
        {
            var response = await mediator.Send(comando);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }

    }
}