using GestaoProdutos.Dominio.Util.Filtros;
using GestaoProdutos.Dominio.Util.Filtros.Enumeradores;

namespace GestaoProdutos.DataTransfer.Pedidos.Request
{
    public class PedidoListarRequest : PaginacaoFiltro
    {

        public int Id { get; set; }
        public int Situacao { get; set; }
        public PedidoListarRequest() : base(cpOrd:"Id", tpOrd: TipoOrdenacaoEnum.Asc)
        {
        }

    }
}