namespace GestaoProdutos.DataTransfer.Pedidos.Request
{
    public record PedidoItemRequest(string DescricaoProduto, double ValorUnitario, int Quantidade);
}