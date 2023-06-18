using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.DataTransfer.Fornecedores.Request;
using GestaoProdutos.DataTransfer.Fornecedores.Response;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Dominio.Fornecedores.Servicos.Comando;

namespace GestaoProdutos.Aplicacao.Fornecedores.Profiles
{
    public class FornecedoresProfile : Profile
    {
        public FornecedoresProfile()
        {
        CreateMap<Fornecedor, FornecedorResponse>();
        CreateMap<FornecedorInserirRequest, FornecedorComando>();
        CreateMap<FornecedorEditarRequest, FornecedorComando>();
        CreateMap<FornecedorListarRequest, FornecedorListarFiltro>();

        }
    }
}