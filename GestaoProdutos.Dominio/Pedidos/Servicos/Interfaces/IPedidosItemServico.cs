using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Servicos.Comandos;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Interfaces
{
    public interface IPedidosItemServico
    {
        Task<PedidoItem> ValidarAsync(int id);
        Task<PedidoItem> InstanciarAsync(PedidoItemComando comando);
        Task<PedidoItem> AlterarSituacaoItemAsync(AlterarSituacaoItemComando comando);
    }
}