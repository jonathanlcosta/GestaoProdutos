using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Pedidos.Repositorios
{
    public class PedidosRepositorio : GenericoRepositorio<Pedido>, IPedidosRepositorio
    {
        public PedidosRepositorio(ISession session) : base(session)
        {
        }
    }
}