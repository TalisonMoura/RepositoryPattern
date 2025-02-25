using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Data.Repositories.Interfaces;

public interface IDepartmentRepository
{
    Task<Department> GetByIdAsync(Guid id);
    Task AddAsync(Department department);
    Task<bool> SaveChangesAsync();
}