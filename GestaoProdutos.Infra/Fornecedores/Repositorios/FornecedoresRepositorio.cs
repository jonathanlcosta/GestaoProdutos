using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Fornecedores
{
    public class FornecedoresRepositorio : GenericoRepositorio<Fornecedor>, IFornecedoresRepositorio
    {
        public FornecedoresRepositorio(ISession session) : base(session)
        {
            
        }
    }
}