using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore.Query;

namespace RepositoryPatternUoW.Data.Repositories.Base.Interfaces;

public interface IGenericRepository<T> where T : class
{
    void Update(T entity);
    void Delete(T entity);
    Task AddAsync(T entity);
    Task<T> GetByIdAsync(Guid id);
    Task<T> FirstAsync(Expression<Func<T, bool>> predicate);
    Task<int> CountAsync(Expression<Func<T, bool>> predicate);
    Task<List<T>> GetDataAsync(Expression<Func<T, bool>> predicate = default, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = default, int? skip = null, int? take = null);
}