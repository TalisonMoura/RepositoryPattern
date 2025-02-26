using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using RepositoryPatternUoW.Data.Repositories.Base.Interfaces;

namespace RepositoryPatternUoW.Data.Repositories.Base;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly DbSet<T> _dbSet;
    private readonly ApplicationContext _context;

    public GenericRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public async Task<T> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> FirstAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.FirstAsync(predicate);
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>> predicate)
    {
        return await _dbSet.CountAsync(predicate);
    }

    public async Task<List<T>> GetDataAsync(
        Expression<Func<T, bool>> predicate = null,
        Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, int? skip = null, int? take = null)
    {
        var query = _dbSet.AsQueryable();

        if (predicate is not null)
            query = query.Where(predicate);

        if (include is not null)
            query = include(query);

        if (skip is not null)
            query = query.Skip(skip.Value);

        if (take is not null)
            query = query.Take(take.Value);

        return await query.ToListAsync();
    }

    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }
}