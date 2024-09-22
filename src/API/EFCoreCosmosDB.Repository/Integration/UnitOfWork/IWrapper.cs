using EFCoreCosmosDB.Repository.Integration.Contract;

namespace EFCoreCosmosDB.Repository.Integration.UnitOfWork;

public interface IWrapper : IDisposable
{
    IBaseRepository<T> GetRepository<T>() where T : class;
    Task<int> SaveChangesAsync();
}
