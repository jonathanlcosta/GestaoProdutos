using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Aplicacao.Fornecedores.Profiles
{
    public class FornecedoresProfile : Profile
    {
        public FornecedoresProfile()
        {
        CreateMap<Fornecedor, FornecedorResponse>();
        }
    }
}