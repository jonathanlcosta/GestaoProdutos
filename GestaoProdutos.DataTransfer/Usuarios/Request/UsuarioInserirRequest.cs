using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.DataTransfer.Usuarios.Response;
using MediatR;

namespace GestaoProdutos.DataTransfer.Usuarios.Request
{
    public class UsuarioInserirRequest : IRequest<UsuarioResponse>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string TipoUsuario { get; set; }
    }
}