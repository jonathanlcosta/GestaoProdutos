using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GestaoProdutos.DataTransfer.Produtos.Request;
using GestaoProdutos.DataTransfer.Produtos.Response;
using GestaoProdutos.Dominio.Produtos.Entidades;

namespace GestaoProdutos.Aplicacao.Produtos.Profiles
{
     public class ProdutosProfile : Profile
    {
        public ProdutosProfile()
        {
        CreateMap<Produto, ProdutoResponse>();
        }
    }
}