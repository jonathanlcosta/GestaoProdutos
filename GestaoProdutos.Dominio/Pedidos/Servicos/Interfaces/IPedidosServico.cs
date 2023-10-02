using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosServico
    {
        Task<Pedido> ValidarAsync(int codigo);
        Task<Pedido> InserirAsync(PedidoComando comando);
        Pedido Instanciar(PedidoComando comando);
        Task<Pedido> EditarAsync(PedidoComando comando);
    }
}