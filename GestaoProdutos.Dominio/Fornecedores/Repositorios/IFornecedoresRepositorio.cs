using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Fornecedores.Entidades;
using GestaoProdutos.Dominio.Fornecedores.Repositorios.Filtros;
using GestaoProdutos.Dominio.Genericos;

namespace GestaoProdutos.Dominio.Fornecedores.Repositorios
{
    public interface IFornecedoresRepositorio : IGenericoRepositorio<Fornecedor>
    {
         IQueryable<Fornecedor> Filtrar(FornecedorListarFiltro filtro);
    }
}