using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class PedidoItemComando
    {
        public string DescricaoProduto { get; set; }
        public double ValorUnitario { get; set; }
        public PedidoPacote Pacote { get; set; }
        public int Quantidade { get; set; }
        public SituacaoPedidoItemEnum Situacao { get; set; }
    }
}