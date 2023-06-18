using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Util;
using GestaoProdutos.Dominio.Util.Filtros.Enumeradores;

namespace GestaoProdutos.Dominio.Genericos
{
    public interface IGenericoRepositorio<T> where T: class
    {
        T Recuperar(int codigo);

        T Inserir(T entidade);

        T Editar(T entidade);

        void Excluir(T entidade);
        void Inserir(IEnumerable<T> entidades);

        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);

        IQueryable<T> Query();

        IList<T> QueryList();
        
    }
}