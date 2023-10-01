using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Autenticacoes.Response;
using GestaoProdutos.Dominio.Autenticacoes.Servicos.Interfaces;
using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios;
using MediatR;

namespace GestaoProdutos.Aplicacao.Autenticacoes.Comandos
{
    public class LoginComandoHandler : IRequestHandler<LoginComando, LoginResponse>
    {
        private readonly IAutenticacoesServico autenticacoesServico;
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public LoginComandoHandler(IAutenticacoesServico autenticacoesServico, IUsuariosRepositorio usuariosRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.autenticacoesServico = autenticacoesServico;
            this.usuariosRepositorio = usuariosRepositorio;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<LoginResponse> Handle(LoginComando request, CancellationToken cancellationToken)
        {
            Usuario login = mapper.Map<Usuario>(request);

           var senha = autenticacoesServico.TransformaSenhaEmHash(request.Senha);

           var usuario = await usuariosRepositorio.RecuperarUsuarioPorEmailSenhaAsync(request.Email, senha);

           if(usuario is null)
           {
             throw new RegraDeNegocioExcecao("Usuario não encontrado");
           }

           var token = autenticacoesServico.GenerateJwtToken(usuario.Email, usuario.TipoUsuario);

           return new LoginResponse(usuario.Email, token);
        }
    }
}