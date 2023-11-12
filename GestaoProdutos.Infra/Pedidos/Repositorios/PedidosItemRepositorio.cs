using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Pedidos.Repositorios
{
    public class PedidosItemRepositorio : GenericoRepositorio<PedidoItem>, IPedidosItemRepositorio
    {
        public PedidosItemRepositorio(ISession session) : base(session)
        {
        }
    }
}