using EFCoreCosmosDB.Repository.Integration.Contract;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCosmosDB.Repository.Integration.Concrete;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected readonly ApplicationDBContext context;
    protected readonly DbSet<T> dbSet;

    public BaseRepository(ApplicationDBContext _context) 
    {
        context = _context ?? throw new ArgumentNullException(nameof(_context));
        dbSet = context.Set<T>();  // Initialize dbSet
    }

    public async Task<IEnumerable<T>> GetAllAsync() => await dbSet.ToListAsync();

    public async Task<T> GetByIdAsync(string id) => await dbSet.FindAsync(id);


    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        _ = context.SaveChangesAsync();
        return entity;
    }

    public async Task UpdateAsync(T entity) =>
        await Task.Run(() =>
        {
            dbSet.Update(entity);
        });


    public async Task DeleteAsync(T entity)
    {
        if (entity != null)
            await Task.Run(() => { dbSet.Remove(entity); });
    }
}