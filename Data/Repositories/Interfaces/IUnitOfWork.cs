namespace RepositoryPatternUoW.Data.Repositories.Interfaces;

public interface IUnitOfWork : IDisposable
{
    bool Commit();
    Task<bool> CommitAsync();
    IDepartmentRepository DepartmentRepository {  get; }
}