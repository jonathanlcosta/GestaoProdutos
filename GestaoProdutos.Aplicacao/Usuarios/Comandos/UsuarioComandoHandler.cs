using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Usuarios.Request;
using GestaoProdutos.DataTransfer.Usuarios.Response;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Repositorios;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;
using GestaoProdutos.Dominio.Usuarios.Servicos.Interfaces;
using MediatR;

namespace GestaoProdutos.Aplicacao.Usuarios.Comandos
{
    public class UsuarioComandoHandler : IRequestHandler<UsuarioInserirRequest, UsuarioResponse>
    {
        private readonly IUsuariosServico usuariosServico;
        private readonly IUsuariosRepositorio usuariosRepositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public UsuarioComandoHandler(IUsuariosServico usuariosServico, IUsuariosRepositorio usuariosRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.usuariosServico = usuariosServico;
            this.usuariosRepositorio = usuariosRepositorio;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<UsuarioResponse> Handle(UsuarioInserirRequest request, CancellationToken cancellationToken)
        {
            UsuarioComando comando = mapper.Map<UsuarioComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Usuario usuario =  await usuariosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<UsuarioResponse>(usuario);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}