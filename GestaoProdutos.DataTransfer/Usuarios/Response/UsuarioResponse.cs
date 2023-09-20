using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Usuarios.Response
{
    public record UsuarioResponse(string Nome, string Email, string Senha);
}