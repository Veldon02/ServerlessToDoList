using Microsoft.EntityFrameworkCore;
using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Interfaces.Repositories;

namespace ServerlessToDoList.Web.Persistence.Repositories;

public class ToDoListItemRepository : BaseRepository<ToDoListItem, Guid>, IToDoListItemRepository
{
    public ToDoListItemRepository(ToDoListDbContext context)
        : base(context)
    {
    }

    public async Task<IEnumerable<ToDoListItem>> GetByListAsync(Guid id)
    {
        return await _dbSet
            .Include(x => x.ToDoList)
            .Where(x => x.ToDoList.Id == id)
            .ToListAsync();
    }
}