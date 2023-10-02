namespace GestaoProdutos.Dominio.Pedidos.Entidades
{
    public class PedidoPacote
    {
        public virtual int Id { get; protected set; }
        public virtual IList<PedidoItem> Itens { get; protected set; }
    }
}