using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> Get(Expression<Func<TEntity, bool>> filtro);
        Task<TEntity> Create(TEntity entidad);
        Task<bool> Update(TEntity entidad);
        Task<bool> Delete(TEntity entidad);
        Task<IQueryable<TEntity>> Query(Expression<Func<TEntity, bool>> filtro = null);
    }
}
