namespace GestaoProdutos.DataTransfer.Pedidos.Response
{
    public class PedidoItemResponse
    {
        public int Id { get; init; }
        public string DescricaoProduto { get; init; }
        public double ValorUnitario { get; init; }
        public int Quantidade { get; init; }
        public int Situacao { get; init; }
    }
}