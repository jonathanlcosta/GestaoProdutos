using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Fornecedores.Entidades;

namespace GestaoProdutos.Infra.Fornecedores.Mapeamentos
{
    public class FornecedoresMap : ClassMap<Fornecedor>
    {
        public FornecedoresMap()
        {
            Schema("GestaoProdutos");
            Table("fornecedor");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Descricao).Column("descricao");
            Map(x=>x.Cnpj).Column("cnpj");
        }
        
    }
}