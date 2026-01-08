using DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        /*
        private readonly BarberiaContext _dbContext;

        public GenericRepository(BarberiaContext dbContext)
        {
            _dbContext = dbContext;
        }*/
        /*
        public Task<T> Create(T entidad)
        {
            
            try
            {
                _dbContext.Set<TEntity>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
            //throw new NotImplementedException();
        }

        public Task<bool> Update(T entidad)
        {
            
            try
            {
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
             
            //throw new NotImplementedException();
        }

        public Task<bool> Delete(T entidad)
        {

             try
            {
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
             
            //throw new NotImplementedException();
        }

        public Task<T> Get(Expression<Func<T, bool>> filtro)
        {
            
             try
            {
                TEntity entidad = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }
             
            //throw new NotImplementedException();
        }

        public Task<IQueryable<T>> Query(Expression<Func<T, bool>> filtro = null)
        {
            
             IQueryable<TEntity> queryEntidad = filtro == null ? _dbContext.Set<TEntity>() : _dbContext
                .Set<TEntity>().Where(filtro);
            return queryEntidad;
             
            //throw new NotImplementedException();
        }
        */
        private readonly List<T> _data = new();

        public Task<T> Create(T entidad)
        {
            _data.Add(entidad);
            return Task.FromResult(entidad);
        }

        public Task<bool> Update(T entidad)
        {
            // En memoria no hacemos nada especial
            return Task.FromResult(true);
        }

        public Task<bool> Delete(T entidad)
        {
            var result = _data.Remove(entidad);
            return Task.FromResult(result);
        }

        public Task<T> Get(Expression<Func<T, bool>> filtro)
        {
            var result = _data.AsQueryable().FirstOrDefault(filtro);
            return Task.FromResult(result);
        }

        public Task<IQueryable<T>> Query(Expression<Func<T, bool>> filtro = null)
        {
            IQueryable<T> query = _data.AsQueryable();
            if (filtro != null)
                query = query.Where(filtro);

            return Task.FromResult(query);
        }
    }
}
