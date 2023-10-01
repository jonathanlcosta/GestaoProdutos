using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Aplicacao.Autenticacoes.Comandos;
using GestaoProdutos.Dominio.Usuarios.Entidades;

namespace GestaoProdutos.Aplicacao.Autenticacoes.Profiles
{
    public class LoginProfile : Profile
    {
         public LoginProfile()
        {
            CreateMap<LoginComando, Usuario>();
        }
    }
}