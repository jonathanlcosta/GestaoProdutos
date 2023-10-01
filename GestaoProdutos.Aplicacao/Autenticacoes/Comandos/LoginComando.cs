using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Autenticacoes.Response;
using MediatR;

namespace GestaoProdutos.Aplicacao.Autenticacoes.Comandos
{
    public class LoginComando : IRequest<LoginResponse>
    {
         public string Email { get; set; }
        public string Senha { get; set; }
    }
}