using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Produtos.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Produtos.Profiles
{
     public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
        CreateMap<Produto, ProdutoResponse>();
        CreateMap<ProdutoInserirRequest, ProdutoComando>();
        CreateMap<ProdutoEditarRequest, ProdutoComando>();
        CreateMap<ProdutoListarRequest, ProdutoListarFiltro>();
        }
    }
}