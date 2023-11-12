using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;
using GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces;

namespace GestaoProdutos.Dominio.Pedidos.Servicos
{
    public class PedidoServico : IPedidosServico
    {
        private readonly IPedidosRepositorio pedidosRepositorio;
        private readonly IPedidosPacoteServico pedidosPacoteServico;
        private readonly IPedidosItemServico pedidosItemServico;

        public PedidoServico(IPedidosRepositorio pedidosRepositorio, IPedidosPacoteServico pedidosPacoteServico, IPedidosItemServico pedidosItemServico)
        {
            this.pedidosRepositorio = pedidosRepositorio;
            this.pedidosPacoteServico = pedidosPacoteServico;
            this.pedidosItemServico = pedidosItemServico;
        }

        public Pedido Inserir(PedidoComando comando)
        {
            Pedido pedido = Instanciar(comando);

            // comando.Pacotes.ForEach(pacote => {
            //     var item = pedidosPacoteServico.Instanciar(pacote);
            //     pacote = item;
            // });

            return pedido;
        }

        public Pedido Instanciar(PedidoComando comando)
        {
           return new Pedido(comando.Descricao);
        }
    }
}