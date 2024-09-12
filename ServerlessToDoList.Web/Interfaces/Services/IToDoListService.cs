using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.ApiModels.ToDoListItem;
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

    public Task<ToDoListItem> AddItemToListAsync(Guid listId, ToDoListItemRequest request);

    public Task RemoveItemFromListAsync(Guid listId, Guid itemId);

    public Task UpdateListItemAsync(Guid listId, Guid itemId, ToDoListItemRequest request);

    public Task UpdateListItemStatusAsync(Guid listId, Guid itemId, ToDoListItemUpdateStatusRequest request);
}