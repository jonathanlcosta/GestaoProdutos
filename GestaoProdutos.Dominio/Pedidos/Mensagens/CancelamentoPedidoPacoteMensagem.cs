namespace GestaoProdutos.Dominio.Pedidos.Mensagens
{
    public class CancelamentoPedidoPacoteMensagem
    {
        public int IdPedido { get; set; }
        public double ValorTotalCancelado { get; set; }
    }
}