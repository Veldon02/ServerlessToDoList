using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Interfaces.Repositories;

public interface IToDoListItemRepository : IBaseRepository<ToDoListItem, Guid>
{
}