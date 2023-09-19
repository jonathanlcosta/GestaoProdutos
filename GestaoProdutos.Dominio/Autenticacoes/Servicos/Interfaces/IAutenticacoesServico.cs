using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Dominio.Autenticacoes.Servicos.Interfaces
{
    public interface IAutenticacoesServico
    {
        string GenerateJwtToken(string email, string tipoUsuario);
        string TransformaSenhaEmHash(string senha);
    }
}