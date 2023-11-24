
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosServico
    {
        Task<Pedido> InserirAsync(PedidoComando comando);
        Pedido Instanciar(PedidoComando comando);
    }
}