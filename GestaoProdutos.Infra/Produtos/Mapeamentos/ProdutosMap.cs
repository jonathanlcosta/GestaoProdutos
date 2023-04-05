using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Produtos.Entidades;
using GestaoProdutos.Dominio.Produtos.Enumeradores;

namespace GestaoProdutos.Infra.Produtos.Mapeamentos
{
    public class ProdutosMap : ClassMap<Produto>
    {
        public ProdutosMap()
        {
            Schema("GestaoProdutos");
            Table("produto");
            Id(x=>x.Codigo).Column("id");
            Map(x=>x.Descricao).Column("descricao");
            Map(x=>x.DataFabricacao).Column("dataFabricacao");
            Map(x=>x.DataValidade).Column("dataValidade");
            Map(x=>x.Situacao).CustomType<SituacaoProdutoEnum>().Column("situacao");
            References(x=>x.Fornecedor).Column("idFornecedor");
        }
    }
}