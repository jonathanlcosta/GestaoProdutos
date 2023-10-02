using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class PedidoItemComando
    {
        public int idProduto { get; set; }
        public decimal ValorUnitario { get; set; }
        public string MotivoCancelamento { get; set; }
        public SituacaoPedidoItemEnum Situacao { get; set; }
    }
}