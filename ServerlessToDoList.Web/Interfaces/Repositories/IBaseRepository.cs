using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Interfaces.Repositories;

public interface IBaseRepository<TEntity, in TId>
    where TEntity : BaseEntity<TId>
{
    Task<TEntity?> GetByIdAsync(TId id);

    Task<IEnumerable<TEntity>> GetAllAsync();

    Task<TEntity> AddAsync(TEntity entity);

    Task UpdateAsync(TEntity entity);

    Task DeleteAsync(TEntity entity);
}