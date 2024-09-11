using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Interfaces.Repositories;

namespace ServerlessToDoList.Web.Persistence.Repositories;

public class ToDoListItemRepository : BaseRepository<ToDoListItem, Guid>, IToDoListItemRepository
{
    public ToDoListItemRepository(ToDoListDbContext context)
        : base(context)
    {
    }
}