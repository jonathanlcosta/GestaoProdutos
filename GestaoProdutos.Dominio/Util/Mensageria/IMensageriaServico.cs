namespace GestaoProdutos.Dominio.Util.Mensageria
{
    public interface IMensageriaServico
    {
        void Publish(string queue, byte[] mensagem);
        byte[] SerializarMensagem<T>(T mensagem);
    }
}