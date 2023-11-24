using AutoMapper;
using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;

namespace GestaoProdutos.Aplicacao.Pedidos.Profiles
{
    public class PedidosProfile : Profile
    {
        public PedidosProfile()
        {
            CreateMap<Pedido, PedidoResponse>();
            CreateMap<PedidoRequest, PedidoComando>();
            CreateMap<PedidoListarRequest, PedidoListarFiltro>();
            CreateMap<PedidoPacoteRequest, PedidoPacoteComando>();
            CreateMap<PedidoItemRequest, PedidoItemComando>();
            CreateMap<PedidoPacote, PedidoPacoteResponse>();
            CreateMap<PedidoItem, PedidoItemResponse>()
            .ForMember(x => x.DescricaoProduto, x => x.MapFrom(x => x.Produto.Descricao));
        }
    }
}