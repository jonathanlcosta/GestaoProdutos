using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class PedidoPacoteComando
    {
        public Pedido Pedido { get; set; }
        public IList<PedidoItemComando> Itens { get; set; }
        public SituacaoPedidoPacoteEnum Situacao { get; set; } 
    }
}