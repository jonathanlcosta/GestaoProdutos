using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Paginacao
{
    public class PaginacaoConsultasProfile : Profile
    {
        public PaginacaoConsultasProfile()
        {
            CreateMap(typeof(PaginacaoConsulta<>), typeof(PaginacaoConsulta<>));
        }
    }
}