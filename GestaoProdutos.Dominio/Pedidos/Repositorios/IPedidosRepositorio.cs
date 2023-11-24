using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Genericos;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Repositorios.Filtros;

namespace GestaoProdutos.Dominio.Pedidos.Repositorios
{
    public interface IPedidosRepositorio : IGenericoRepositorio<Pedido>
    {
       Task<IQueryable<Pedido>> FiltrarAsync(PedidoListarFiltro filtro);
    }
}