using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class Pedido
    {

        public virtual int Id { get; protected set; }
        public virtual string Descricao { get; protected set; }
        public virtual IList<PedidoPacote> Pacotes { get; protected set; }
        public virtual DateTime DataCriacao { get; protected set; }
        public virtual SituacaoPedidoEnum Situacao { get; set; }
        public Pedido(string descricao)
        {
            Descricao = descricao;
            Pacotes = new List<PedidoPacote>();
            DataCriacao = DateTime.Now;
            Situacao = SituacaoPedidoEnum.Pendente;
        }

        protected Pedido(){}

        public virtual void SetDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public virtual void SetSituacao(SituacaoPedidoEnum situacao)
        {
            Situacao = situacao;
        }

    }
}