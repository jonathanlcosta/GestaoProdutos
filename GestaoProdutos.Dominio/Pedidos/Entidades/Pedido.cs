using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class Pedido
    {

        public int Id { get; protected set; }
        public string Descricao { get; protected set; }
        public IList<PedidoPacote> Pacotes { get; protected set; }
        public DateTime DataCriacao { get; protected set; }
        public Pedido(string descricao)
        {
            Descricao = descricao;
            Pacotes = new List<PedidoPacote>();
            DataCriacao = DateTime.Now;
        }

        protected Pedido(){}

        public void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }


    }
}