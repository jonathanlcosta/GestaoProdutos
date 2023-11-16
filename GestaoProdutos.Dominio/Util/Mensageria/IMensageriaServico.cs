namespace GestaoProdutos.Dominio.Util.Mensageria
{
    public interface IMensageriaServico
    {
        void Publish<T>(string queue, T evento);
        byte[] SerializarMensagem<T>(T mensagem);
    }
}