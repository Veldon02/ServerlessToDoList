using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Interfaces.Repositories;

namespace ServerlessToDoList.Web.Persistence.Repositories;

public class ToDoListRepository : BaseRepository<ToDoList, Guid>, IToDoListRepository
{
    public ToDoListRepository(ToDoListDbContext context)
        : base(context)
    {
    }
}