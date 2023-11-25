using AutoMapper;
using GestaoProdutos.Aplicacao.Pedidos.Servicos.Interfaces;
using GestaoProdutos.Aplicacao.Transacoes.Interfaces;
using GestaoProdutos.DataTransfer.Pedidos.Request;
using GestaoProdutos.DataTransfer.Pedidos.Response;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;
using Microsoft.Extensions.Logging;

namespace GestaoProdutos.Aplicacao.Pedidos.Servicos
{
    public class PedidosItemAppServico : IPedidosItemAppServico
    {
        private readonly IPedidosItemServico pedidosItemServico;
        private readonly IPedidosItemRepositorio pedidosItemRepositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ILogger<PedidosItemAppServico> logger;

        public PedidosItemAppServico(IPedidosItemServico pedidosItemServico, IPedidosItemRepositorio pedidosItemRepositorio, IUnitOfWork unitOfWork, IMapper mapper, ILogger<PedidosItemAppServico> logger)
        {
            this.pedidosItemServico = pedidosItemServico;
            this.pedidosItemRepositorio = pedidosItemRepositorio;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<PedidoItemResponse> AlterarSituacaoPedidoItem(int codigoItem, AlterarSituacaoItemRequest request)
        {
           AlterarSituacaoItemComando comando = mapper.Map<AlterarSituacaoItemComando>(request);
           comando.Id = codigoItem;
            try
            {
                unitOfWork.BeginTransaction();
                PedidoItem pedidoItem = await pedidosItemServico.AlterarSituacaoItemAsync(comando);
                unitOfWork.Commit();
                return mapper.Map<PedidoItemResponse>(pedidoItem);
            }
            catch
            {
                logger.LogError("Algo deu errado ao alterar a situação do item");
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}