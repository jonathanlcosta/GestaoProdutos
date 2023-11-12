using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class AlterarSituacaoItemComando
    {
        public int Id { get; set; }
        public SituacaoPedidoItemEnum Situacao { get; set; }
    }
}