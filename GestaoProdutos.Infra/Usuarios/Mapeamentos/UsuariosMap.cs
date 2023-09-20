using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using GestaoProdutos.Dominio.Usuarios.Entidades;

namespace GestaoProdutos.Infra.Usuarios.Mapeamentos
{
    public class UsuariosMap : ClassMap<Usuario>
    {
        public UsuariosMap()
        {
            Schema("GestaoProdutos");
            Table("USUARIOS");
            Id(x=>x.Id).Column("id");
            Map(x=>x.Nome).Column("nome");
            Map(x=>x.Email).Column("email");
            Map(x=>x.Senha).Column("senha");
        }
    }
}