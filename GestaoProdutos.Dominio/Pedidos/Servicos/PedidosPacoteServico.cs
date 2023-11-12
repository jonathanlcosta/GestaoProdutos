using GestaoProdutos.Dominio.Execoes;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Pedidos.Servicos
{
    public class PedidosPacoteServico : IPedidosPacoteServico
    {
        private readonly IPedidosPacoteRepositorio pedidosPacoteRepositorio;
        private readonly IPedidosRepositorio pedidosRepositorio;

        public PedidosPacoteServico(IPedidosPacoteRepositorio pedidosPacoteRepositorio, IPedidosRepositorio pedidosRepositorio)
        {
            this.pedidosPacoteRepositorio = pedidosPacoteRepositorio;
            this.pedidosRepositorio = pedidosRepositorio;
        }

        public PedidoPacote Instanciar(PedidoPacoteComando comando)
        {
            return new(comando.Pedido);
        }

        public async Task<PedidoPacote> ValidarAsync(int id)
        {
            var pacote = await pedidosPacoteRepositorio.RecuperarAsync(id);
            if(pacote is null)
            throw new RegraDeNegocioExcecao("O pacote não foi encontrado");

            return pacote;
        }

        public async Task AlterarPedidoParaCanceladoAsync(PedidoPacote pacote)
        {
            pacote.Pedido.SetSituacao(SituacaoPedidoEnum.Cancelado);
            await pedidosRepositorio.EditarAsync(pacote.Pedido);
        }  
    }
}