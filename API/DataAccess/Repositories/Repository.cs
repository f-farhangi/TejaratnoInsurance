using API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        #region Fields

        private readonly DbContext _dbContext;

        #endregion

        #region Constructor

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        #endregion

        #region Methods

        public async Task Delete(long id)
        {
            var entity = await GetAsync(p => p.Id == id);

            if (entity != null)
            {
                _dbContext.Set<TEntity>().Remove(entity);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null, bool noTracking = false)
        {
            IQueryable<TEntity> query;

            if (noTracking)
                query = _dbContext.Set<TEntity>().AsNoTracking();
            else
                query = _dbContext.Set<TEntity>();

            foreach (var include in includes ?? new List<string>())
                query = query.Include(include);

            if (predicate == null)
                return await query.ToListAsync();

            return await query.Where(predicate).ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate = null, List<string> includes = null, bool noTracking = false)
        {
            IQueryable<TEntity> query;

            if (noTracking)
                query = _dbContext.Set<TEntity>().AsNoTracking();
            else
                query = _dbContext.Set<TEntity>();

            foreach (var include in includes ?? new List<string>())
            {
                query = query.Include(include);
            }

            if (predicate == null)
                return await query.SingleOrDefaultAsync();

            return await query.Where(predicate).SingleOrDefaultAsync();
        }

        public async Task Insert(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        #endregion
    }
}
