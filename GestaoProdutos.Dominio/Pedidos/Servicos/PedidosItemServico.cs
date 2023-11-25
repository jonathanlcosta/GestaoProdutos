using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;
using GestaoProdutos.Dominio.Pedidos.Mensagens;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Produtos.Servicos.Interfaces;
using GestaoProdutos.Dominio.Util.Mensageria;

namespace GestaoProdutos.Dominio.Pedidos.Servicos
{
    public class PedidosItemServico : IPedidosItemServico
    {
        private readonly IProdutosServico produtosServico;
        private readonly IPedidosItemRepositorio pedidosItemRepositorio;
        private readonly IPedidosPacoteRepositorio pedidosPacoteRepositorio;
        private readonly IPedidosPacoteServico pedidosPacoteServico;
        private readonly IMensageriaServico mensageriaServico;
        private const string QUEUE = "cancelamento-pacotes";

        public PedidosItemServico(IProdutosServico produtosServico, IPedidosItemRepositorio pedidosItemRepositorio, IPedidosPacoteRepositorio pedidosPacoteRepositorio, IPedidosPacoteServico pedidosPacoteServico, IMensageriaServico mensageriaServico)
        {
            this.produtosServico = produtosServico;
            this.pedidosItemRepositorio = pedidosItemRepositorio;
            this.pedidosPacoteRepositorio = pedidosPacoteRepositorio;
            this.pedidosPacoteServico = pedidosPacoteServico;
            this.mensageriaServico = mensageriaServico;
        }

        public async Task<PedidoItem> InstanciarAsync(PedidoItemComando comando)
        {
            var produto = await produtosServico.RecuperarPorDescricaoAsync(comando.DescricaoProduto);
            return new(produto, comando.Quantidade, comando.ValorUnitario, comando.Pacote);
        }

        public async Task<PedidoItem> ValidarAsync(int id)
        {
           var produto = await pedidosItemRepositorio.RecuperarAsync(id);

           if(produto is null)
            throw new RegraDeNegocioExcecao("O item do pedido não foi encontrado");

            return produto;
        }

        public async Task<PedidoItem> AlterarSituacaoItemAsync(AlterarSituacaoItemComando comando)
        {
            var item = await ValidarAsync(comando.Id);
            item.SetSituacao(comando.Situacao);
            await pedidosItemRepositorio.EditarAsync(item);

            switch (comando.Situacao)
            {
                case SituacaoPedidoItemEnum.Cancelado:
                    await CancelarPacoteAsync(item);
                    break;

                case SituacaoPedidoItemEnum.Entregue:
                    await ValidarSeTodosItensForamEntregues(item);
                    break;
            }
            return item;
        }

        public async Task CancelarPacoteAsync(PedidoItem pedidoItem)
        {
            pedidoItem.Pacote.SetSituacao(SituacaoPedidoPacoteEnum.Cancelado);
            await pedidosPacoteRepositorio.EditarAsync(pedidoItem.Pacote);
            await pedidosPacoteServico.AlterarPedidoParaCanceladoAsync(pedidoItem.Pacote);

            double valorTotalCancelado = pedidoItem.Pacote.Pedido.Pacotes.Where(x => x.Situacao == SituacaoPedidoPacoteEnum.Cancelado).SelectMany(pacote => pacote.Itens)
            .Sum(item => item.ValorUnitario * item.Quantidade);

            CancelamentoPedidoPacoteMensagem mensagem = new()
            {
                IdPedido = pedidoItem.Pacote.Pedido.Id,
                ValorTotalCancelado = valorTotalCancelado
            };
            mensageriaServico.Publish(QUEUE, mensagem);
        }

        public async Task ValidarSeTodosItensForamEntregues(PedidoItem item)
        {
            bool todosItensEntregues = item.Pacote.Itens.All(x => x.Situacao == SituacaoPedidoItemEnum.Entregue);
            if(todosItensEntregues)
            {
            item.Pacote.SetSituacao(SituacaoPedidoPacoteEnum.Entregue);
            await pedidosPacoteRepositorio.EditarAsync(item.Pacote);
            }
        }
    }
}