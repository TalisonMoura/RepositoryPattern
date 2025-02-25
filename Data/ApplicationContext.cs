using Microsoft.EntityFrameworkCore;
using RepositoryPatternUoW.Domain;

namespace RepositoryPatternUoW.Data;

public class ApplicationContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Department> Departments { get; set; }
}