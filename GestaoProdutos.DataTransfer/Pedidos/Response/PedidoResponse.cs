namespace GestaoProdutos.DataTransfer.Pedidos.Response
{
    public class PedidoResponse
    {
        public int Id { get; init; }
        public string Descricao { get; init; }
        public List<PedidoPacoteResponse> Pacotes { get; init; }
        public DateTime DataCriacao { get; init; }
        public int Situacao { get; init; }

    }
}