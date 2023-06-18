using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Infra.Genericos;
using NHibernate;

namespace GestaoProdutos.Infra.Fornecedores
{
    public class FornecedoresRepositorio : GenericoRepositorio<Fornecedor>, IFornecedoresRepositorio
    {
        public FornecedoresRepositorio(ISession session) : base(session)
        {
            
        }

        public IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro)
        {
           IQueryable<Fornecedor> query = Query();

            if (!string.IsNullOrWhiteSpace(filtro.Descricao))
            {
                 query = query.Where(p => p.Descricao.Contains(filtro.Descricao));
            }

            if (!string.IsNullOrWhiteSpace(filtro.Cnpj))
            {
                 query = query.Where(p => p.Cnpj.Contains(filtro.Cnpj));
            }

            return query;
        }
    }
}