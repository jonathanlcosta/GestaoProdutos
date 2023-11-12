using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Pedidos.Repositorios
{
    public class PedidosPacoteRepositorio : GenericoRepositorio<PedidoPacote>, IPedidosPacoteRepositorio
    {
        public PedidosPacoteRepositorio(ISession session) : base(session)
        {
        }
    }
}