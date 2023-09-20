using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Autenticacoes.Servicos.Interfaces;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;
using GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Usuarios.Servicos
{
    public class UsuariosServico : IUsuariosServico
    {
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IAutenticacoesServico autenticacoesServico;

        public UsuariosServico(IUsuariosRepositorio usuariosRepositorio, IAutenticacoesServico autenticacoesServico)
        {
            this.usuariosRepositorio = usuariosRepositorio;
            this.autenticacoesServico = autenticacoesServico;
        }

        public async Task<Usuario> InserirAsync(UsuarioComando comando)
        {
            Usuario usuario = Instanciar(comando);
            await usuariosRepositorio.InserirAsync(usuario);
            return usuario;
        }

        public Usuario Instanciar(UsuarioComando comando)
        {
            string senhaHash = autenticacoesServico.TransformaSenhaEmHash(comando.Senha);
            return new Usuario(comando.Nome, comando.Email, senhaHash);
        }

        public async Task<Usuario> RecuperarAsync(int id)
        {
            Usuario usuario = await usuariosRepositorio.RecuperarAsync(id);
            if(usuario is null)
            throw new RegraDeNegocioExcecao("Usuario não encontrado");
            return usuario;
        }

        public async Task<Usuario> RecuperarUsuarioPorEmailSenha(string email, string senha)
        {
            var query = await usuariosRepositorio.QueryAsync();
            Usuario usuario = query.Where(x => x.Email == email && x.Senha == senha).FirstOrDefault();
            return usuario;
        }
    }
}