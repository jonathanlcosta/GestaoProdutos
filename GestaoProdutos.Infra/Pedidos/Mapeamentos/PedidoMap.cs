using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Pedidos.Entidades;
using GestaoProdutos.Dominio.Pedidos.Enumeradores;

namespace GestaoProdutos.Infra.Pedidos.Mapeamentos
{
    public class PedidoMap : ClassMap<Pedido>
    {
        public PedidoMap()
        {
            Schema("GestaoProdutos");
            Table("pedido");
            Id(x => x.Id, "id");
            Map(x => x.Descricao, "descricao");
            Map(x => x.DataCriacao, "dataCriacao");
            Map(x => x.Situacao, "situacao").CustomType<SituacaoPedidoEnum>();
            HasMany(x => x.Pacotes).Cascade.All();
        }
    }
}