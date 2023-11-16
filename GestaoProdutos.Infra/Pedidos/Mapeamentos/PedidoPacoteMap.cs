using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Infra.Pedidos.Mapeamentos
{
    public class PedidoPacoteMap : ClassMap<PedidoPacote>
    {
        public PedidoPacoteMap()
        {
            Schema("GestaoProdutos");
            Table("pedidopacote");
            Id(x => x.Id, "id");
            References(x => x.Pedido, "idPedido");
            Map(x => x.Situacao, "situacao").CustomType<SituacaoPedidoPacoteEnum>();
            HasMany(x => x.Itens).Cascade.All();
        }
    }
}