using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.DataTransfer.Autenticacoes.Response
{
    public class LoginResponse
    {
        public LoginResponse(string email, string token)
        {
            Email = email;
            Token = token;
        }

        public string Email { get;  set; }
        public string Token { get;  set; }
    }
}