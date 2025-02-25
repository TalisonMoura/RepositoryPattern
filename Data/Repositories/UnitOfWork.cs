using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationContext _context;

    public UnitOfWork(ApplicationContext context)
    {
        _context = context;
    }

    public bool Commit()
    {
        return _context.SaveChanges() > 0;
    }

    public async Task<bool> CommitAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
