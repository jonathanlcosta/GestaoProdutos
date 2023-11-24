using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Dominio.Pedidos.Repositorios.Filtros;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Pedidos.Repositorios
{
    public class PedidosRepositorio : GenericoRepositorio<Pedido>, IPedidosRepositorio
    {
        public PedidosRepositorio(ISession session) : base(session)
        {
        }

        public async Task<IQueryable<Pedido>> FiltrarAsync(PedidoListarFiltro filtro)
        {
            IQueryable<Pedido> query = await QueryAsync();

             if(filtro.Id != 0)
            {
                query = query.Where(x => x.Id == filtro.Id);
            }

            switch (filtro.Situacao)
            {
                case 1:
                    query = query.Where(x => x.Situacao == SituacaoPedidoEnum.Pendente);
                    break;
                case 2:
                    query = query.Where(x => x.Situacao == SituacaoPedidoEnum.EmTransito);
                    break;
                case 3:
                    query = query.Where(x => x.Situacao == SituacaoPedidoEnum.Entregue);
                    break;
                case 4:
                    query = query.Where(x => x.Situacao == SituacaoPedidoEnum.Cancelado);
                    break;
                default:
                    break;
            }

            return query;
        }
    }
}