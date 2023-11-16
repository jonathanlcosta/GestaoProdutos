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

        public async Task<Pedido> Inserir(PedidoComando comando)
        {
            Pedido pedido = Instanciar(comando);

            comando.Pacotes.ForEach(pacote => {
                pacote.Pedido = pedido;
                PedidoPacote pedidoPacote = pedidosPacoteServico.Instanciar(pacote);
                pedido.Pacotes.Add(pedidoPacote);
                
                pacote.Itens.ForEach(async item => {

                item.Pacote = pedidoPacote;
                PedidoItem pedidoItem = await pedidosItemServico.InstanciarAsync(item);
                pedidoPacote.Itens.Add(pedidoItem);
                }
                );
            });

            await pedidosRepositorio.InserirAsync(pedido);

            return pedido;
        }

        public Pedido Instanciar(PedidoComando comando)
        {
           return new Pedido(comando.Descricao);
        }
    }
}