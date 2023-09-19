using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestaoProdutos.Dominio.Genericos;
using GestaoProdutos.Dominio.Util;
using GestaoProdutos.Dominio.Util.Filtros.Enumeradores;
using NHibernate;
using System.Linq.Dynamic.Core;
using NHibernate.Linq;

namespace GestaoProdutos.Infra.Genericos
{
    public class GenericoRepositorio<T> : IGenericoRepositorio<T> where T : class
    {
         protected readonly ISession session;
        public GenericoRepositorio(ISession session)
        {
            this.session = session;
        }
        public T Editar(T entidade)
        {
            session.Update(entidade);
            return entidade;
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public T Inserir(T entidade)
        {
            session.Save(entidade);
            return entidade;
        }

        public void Inserir(IEnumerable<T> entidades)
        {
            foreach (T entidade in entidades)
            {
                session.Save(entidade);
            }
        }

         public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return Paginar(query, qt, pg);
            }
            catch
            {
                throw new ArgumentException("Campo da ordenação não informado");
            }
        }

        private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
                Total = query.LongCount(),
            };
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

         public IList<T> QueryList()
        {
            return session.Query<T>().ToList();
        }


        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        public async Task<T> InserirAsync(T entidade)
        {
           await session.SaveAsync(entidade);
           return entidade;
        }

        public async Task<IList<T>> ListarAsync()
        {
          var query = await session.Query<T>().ToListAsync();
            return query;
        }

        public async Task<T> RecuperarAsync(int id)
        {
            var retorno = await session.GetAsync<T>(id);
            return retorno;
        }

        public async Task<T> EditarAsync(T entidade)
        {
            await session.UpdateAsync(entidade);
            return entidade;
        }

        public async Task ExcluirAsync(T entidade)
        {
            await session.DeleteAsync(entidade);
        }

        public async Task<IQueryable<T>> QueryAsync()
        {
            List<T> resultado = await session.Query<T>().ToListAsync();
            return resultado.AsQueryable();
        }

        public Task InserirAsync(IEnumerable<T> entidades)
        {
            throw new NotImplementedException();
        }
    }
}