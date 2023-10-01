using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios;
using GestaoProdutos.Infra.Genericos;
using NHibernate;
using NHibernate.Linq;

namespace GestaoProdutos.Infra.Usuarios.Repositorios
{
    public class UsuariosRepositorio : GenericoRepositorio<Usuario>, IUsuariosRepositorio
    {
        public UsuariosRepositorio(ISession session) : base(session)
        {
        }

        public async Task<Usuario> RecuperarUsuarioPorEmailSenhaAsync(string email, string senha)
        {
            return await Query().Where(x => x.Email == email && x.Senha == senha).FirstOrDefaultAsync();
        }
    }
}