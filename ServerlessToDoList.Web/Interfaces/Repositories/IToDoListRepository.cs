using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Interfaces.Repositories;

public interface IToDoListRepository : IBaseRepository<ToDoList, Guid>
{
}