using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class PedidoPacoteComando
    {
        public virtual IList<PedidoItemComando> Itens { get; set; }
        public virtual SituacaoPedidoPacoteEnum Situacao { get; set; } 
    }
}