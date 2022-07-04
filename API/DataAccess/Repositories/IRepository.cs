using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace API.DataAccess
{
    public interface IRepository<T> where T : class, IEntity
    {
        #region Methods

        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null, List<string> includes = default, bool noTracking = false);
        Task<T> GetAsync(Expression<Func<T, bool>> predicate = null, List<string> includes = default, bool noTracking = false);
        Task Insert(T entity);
        Task Update(T entity);
        Task Delete(long id);
        Task SaveAsync();

        #endregion
    }
}
