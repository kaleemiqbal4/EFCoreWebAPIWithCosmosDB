using EFCoreCosmosDB.Repository.Integration.Concrete;
using EFCoreCosmosDB.Repository.Integration.Contract;
using System.Collections.Concurrent;

namespace EFCoreCosmosDB.Repository.Integration.UnitOfWork;

public class Wrapper : IWrapper
{
    private readonly ApplicationDBContext _context;
    private readonly ConcurrentDictionary<Type, object> _repositories = new ConcurrentDictionary<Type, object>();
    private bool _disposed = false;

    public Wrapper(ApplicationDBContext context)
    {
        _context = context;
    }

    public IBaseRepository<T> GetRepository<T>() where T : class
    {
        return (IBaseRepository<T>)_repositories.GetOrAdd(typeof(T), _ => new BaseRepository<T>(_context));
    }

    public async Task<int> SaveChangesAsync()
    {
        // Here, you can start a transaction if necessary
        using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var result = await _context.SaveChangesAsync();
            await transaction.CommitAsync();
            return result;
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            _disposed = true;
        }
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
