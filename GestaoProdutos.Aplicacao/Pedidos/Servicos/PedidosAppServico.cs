using AutoMapper;
using GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Repositorios.Filtros;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Util;

namespace GestaoProdutos.Aplicacao.Pedidos.Servicos
{
    public class PedidosAppServico : IPedidosAppServico
    {
        private readonly IPedidosServico pedidosServico;
        private readonly IPedidosRepositorio pedidosRepositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PedidosAppServico(IPedidosServico pedidosServico, IPedidosRepositorio pedidosRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.pedidosServico = pedidosServico;
            this.pedidosRepositorio = pedidosRepositorio;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PedidoResponse> InserirAsync(PedidoRequest request)
        {
            PedidoComando comando = mapper.Map<PedidoComando>(request);
            try
            {
                unitOfWork.BeginTransaction();
                Pedido pedido = await pedidosServico.InserirAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<PedidoResponse>(pedido);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }

        public async Task<PaginacaoConsulta<PedidoResponse>> ListarAsync(PedidoListarRequest request)
        {
            PedidoListarFiltro filtro = mapper.Map<PedidoListarFiltro>(request);
            IQueryable<Pedido> query = await pedidosRepositorio.FiltrarAsync(filtro);

            PaginacaoConsulta<Pedido> Pedidos = pedidosRepositorio.Listar(query, request.Qt, request.Pg, request.CpOrd, request.TpOrd);

            return mapper.Map<PaginacaoConsulta<PedidoResponse>>(Pedidos);
        }

        public async Task<PedidoResponse> RecuperarAsync(int codigo)
        {
            Pedido pedido = await pedidosRepositorio.RecuperarAsync(codigo);
            return mapper.Map<PedidoResponse>(pedido);
        }
    }
}