using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.DataTransfer.Usuarios.Request;
using GestaoProdutos.DataTransfer.Usuarios.Response;
using GestaoProdutos.Dominio.Usuarios.Entidades;
using GestaoProdutos.Dominio.Usuarios.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Usuarios.Profiles
{
    public class UsuariosProfile : Profile
    {
        public UsuariosProfile()
        {
        CreateMap<Usuario, UsuarioResponse>();
        CreateMap<UsuarioInserirRequest, UsuarioComando>();
        }
    }
}