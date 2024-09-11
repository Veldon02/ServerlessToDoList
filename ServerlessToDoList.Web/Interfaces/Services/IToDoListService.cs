using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Interfaces.Services;

public interface IToDoListService
{
    public Task<IEnumerable<ToDoList>> GetAllAsync();

    public Task<ToDoList> GetByIdAsync(Guid id);

    public Task<IEnumerable<ToDoListItem>> GetListItemsAsync(Guid id);

    public Task<ToDoList> CreateListAsync(ToDoListRequest request);

    public Task UpdateListAsync(Guid id, ToDoListRequest request);

    public Task DeleteListAsync(Guid id);
}