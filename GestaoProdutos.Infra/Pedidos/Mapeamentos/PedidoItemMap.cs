using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Infra.Pedidos.Mapeamentos
{
    public class PedidoItemMap : ClassMap<PedidoItem>
    {
        public PedidoItemMap()
        {
            Schema("GestaoProdutos");
            Table("pedidoitem");
            Id(x => x.Id, "id");
            References(x => x.Produto, "idProduto");
            References(x => x.Pacote, "idPacote");
            Map(x => x.Quantidade, "quantidade");
            Map(x => x.ValorUnitario, "valorUnitario");
            Map(x => x.Situacao, "situacao").CustomType<SituacaoPedidoItemEnum>();
        }
    }
}