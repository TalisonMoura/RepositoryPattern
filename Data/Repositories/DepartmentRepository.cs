using RepositoryPatternUoW.Domain;
using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Data.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly ApplicationContext _context;

    public DepartmentRepository(ApplicationContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Department department)
    {
        await _context.Departments.AddAsync(department);
    }

    public async Task<Department> GetByIdAsync(Guid id)
    {
        return await _context.Departments.Include(x => x.Employees).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}