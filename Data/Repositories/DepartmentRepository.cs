using RepositoryPatternUoW.Domain;
using RepositoryPatternUoW.Data.Repositories.Base;
using RepositoryPatternUoW.Data.Repositories.Interfaces;

namespace RepositoryPatternUoW.Data.Repositories;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{

    public DepartmentRepository(ApplicationContext context) : base(context)
    {

    }
}