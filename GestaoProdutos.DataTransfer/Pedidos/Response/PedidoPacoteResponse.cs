namespace GestaoProdutos.DataTransfer.Pedidos.Response
{
    public class PedidoPacoteResponse
    {
        public int Id { get; init; }
        public List<PedidoItemResponse> Itens { get; init; }
        public int Situacao { get; init; }
    }
}