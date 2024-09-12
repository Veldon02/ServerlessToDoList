using Microsoft.EntityFrameworkCore;
using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Exceptions;
using ServerlessToDoList.Web.Interfaces.Repositories;

namespace ServerlessToDoList.Web.Persistence.Repositories;

public class BaseRepository<TEntity, TId> : IBaseRepository<TEntity, TId>
    where TEntity : BaseEntity<TId>
{
    private readonly ToDoListDbContext _context;
    protected readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ToDoListDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity?> GetByIdAsync(TId id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> GetByIdOrThrowAsync(TId id)
    {
        return await GetByIdAsync(id)
               ?? throw new EntityNotFoundException($"{typeof(TEntity).Name} with id {id} is not found");
    }

    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);

        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task UpdateAsync(TEntity entity)
    {
        _dbSet.Update(entity);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity)
    {
        _dbSet.Remove(entity);

        await _context.SaveChangesAsync();
    }
}