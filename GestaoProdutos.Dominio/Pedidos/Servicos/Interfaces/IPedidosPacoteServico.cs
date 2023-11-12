using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosPacoteServico
    {
        Task<PedidoPacote> ValidarAsync(int id);
        PedidoPacote Instanciar(PedidoPacoteComando comando);
        Task AlterarPedidoParaCanceladoAsync(PedidoPacote pacote);
    }
}