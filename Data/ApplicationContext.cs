using RepositoryPatternUoW.Domain;
using Microsoft.EntityFrameworkCore;

namespace RepositoryPatternUoW.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }

    public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
    {
        
    }
}