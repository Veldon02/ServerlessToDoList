using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Interfaces.Services;

public interface IToDoListService
{
    public Task<IEnumerable<ToDoList>> GetAllAsync();

    public Task<ToDoList> GetByIdAsync(Guid id);

    public Task<IEnumerable<ToDoListItem>> GetListItemsAsync(Guid id);
}