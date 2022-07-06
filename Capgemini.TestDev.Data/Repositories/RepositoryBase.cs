using Capgemini.TestDev.Data.Context;
using Capgemini.TestDev.Data.Extensions;
using Capgemini.TestDev.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Capgemini.TestDev.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TestDevContext _testDevContext;

        public Repository(TestDevContext testDevContext)
        {

            _testDevContext = testDevContext; 
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where) => await _testDevContext.Set<TEntity>().Where(where).ToListAsync();

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _testDevContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes);

            return await query.Where(where).ToListAsync();
        }

        public async Task<IList<TEntity>> CustomFindNoTracking(Expression<Func<TEntity, bool>> where, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _testDevContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes).AsNoTracking();

            return await query.Where(where).ToListAsync();
        }

        public async Task<int> Count() => await _testDevContext.Set<TEntity>().CountAsync();

        public async Task<bool> Existe(Expression<Func<TEntity, bool>> where)
        {
            return await _testDevContext.Set<TEntity>().Where(where).AnyAsync();
        }

        public async Task<IList<TEntity>> CustomFind(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, int>> orderBy, params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _testDevContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes);

            return await query.Where(where).OrderBy(orderBy).ToListAsync();
        }

        public async Task<IList<TEntity>> GetAll() => await _testDevContext.Set<TEntity>().ToListAsync();

        public async Task<IList<TEntity>> GetAllNoTracking() => await _testDevContext.Set<TEntity>().AsNoTracking().ToListAsync();

        public async Task<IList<TEntity>> GetAllWithInclude(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _testDevContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes);

            return await query.ToListAsync();
        }

        public async Task<IList<TEntity>> GetAllWithIncludeNoTracking(params Expression<Func<TEntity, object>>[] includes)
        {
            var query = _testDevContext.Set<TEntity>() as IQueryable<TEntity>;
            query = query.EagerLoad(includes).AsNoTracking();

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id) => await _testDevContext.Set<TEntity>().FindAsync(id);

        public void Save(TEntity entity) => _testDevContext.Add(entity);

        public void SaveMany(IEnumerable<TEntity> entity) => _testDevContext.AddRange(entity);

        public void Delete(TEntity entity) => _testDevContext.Remove(entity);

        public void DeleteMany(IEnumerable<TEntity> entity) => _testDevContext.RemoveRange(entity);

        public void UpdateRange(List<TEntity> e) => _testDevContext.Set<TEntity>().UpdateRange(e);

        public void Update(TEntity e) => _testDevContext.Set<TEntity>().Update(e);
    }
}
