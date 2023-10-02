using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Servicos.Comandos
{
    public class PedidoComando
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public List<PedidoPacoteComando> Pacotes { get; set; }
        public DateTime DataCriacao { get; set; }
        public SituacaoPedidoEnum Situacao { get; set; }
    }
}