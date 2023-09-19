using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces
{
    public interface IUsuariosServico
    {
        Task<Usuario> InserirAsync(UsuarioComando comando);
        Usuario Instanciar(UsuarioComando comando);
        Task<Usuario> RecuperarAsync(int id);
        
    }
}