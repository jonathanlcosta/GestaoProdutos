namespace GestaoProdutos.DataTransfer.Pedidos.Request
{
    public record PedidoRequest(string Descricao,List<PedidoPacoteRequest> Pacotes);
  
}