using RepositoryPatternUoW.Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly DbSet<Department> _dbSet;
    private readonly ApplicationContext _context;

    public DepartmentRepository(ApplicationContext context)
    {
        _context = context;
        _dbSet = _context.Set<Department>();
    }

    public async Task AddAsync(Department department)
    {
        await _dbSet.AddAsync(department);
    }

    public async Task<Department> GetByIdAsync(Guid id)
    {
        return await _dbSet.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
    }
}