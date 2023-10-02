using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class PedidoPacote
    {

        public virtual int Id { get; protected set; }
        public virtual IList<PedidoItem> Itens { get; protected set; }
        public virtual Pedido Pedido { get; protected set; }
        public virtual SituacaoPedidoPacoteEnum Situacao { get; protected set; }
        protected PedidoPacote()
        {}
        public PedidoPacote(Pedido pedido)
        {
            Itens = new List<PedidoItem>();
            Situacao = SituacaoPedidoPacoteEnum.Pendente;
            SetPedido(pedido);
        }

        public virtual void SetSituacao(SituacaoPedidoPacoteEnum situacao)
        {
            Situacao = situacao;
        }

        public virtual void SetPedido(Pedido pedido)
        {
            Pedido = pedido;
        }
    }
}