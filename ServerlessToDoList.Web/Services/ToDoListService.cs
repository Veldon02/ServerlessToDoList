using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.ApiModels.ToDoListItem;
using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Enums;
using ServerlessToDoList.Web.Interfaces.Repositories;
using ServerlessToDoList.Web.Interfaces.Services;

namespace ServerlessToDoList.Web.Services;

public class ToDoListService : IToDoListService
{
    private readonly IToDoListRepository _toDoListRepository;
    private readonly IToDoListItemRepository _toDoListItemRepository;

    public ToDoListService(IToDoListRepository toDoListRepository, IToDoListItemRepository toDoListItemRepository)
    {
        _toDoListRepository = toDoListRepository;
        _toDoListItemRepository = toDoListItemRepository;
    }

    public async Task<IEnumerable<ToDoList>> GetAllAsync()
    {
        return await _toDoListRepository.GetAllAsync();
    }

    public async Task<ToDoList> GetByIdAsync(Guid id)
    {
        return await _toDoListRepository.GetByIdOrThrowAsync(id);
    }

    public async Task<IEnumerable<ToDoListItem>> GetListItemsAsync(Guid id)
    {
        var list = await _toDoListRepository.GetByIdOrThrowAsync(id);

        return await _toDoListItemRepository.GetByListAsync(list.Id);
    }

    public async Task<ToDoList> CreateListAsync(ToDoListRequest request)
    {
        return await _toDoListRepository.AddAsync(new ToDoList { Name = request.Name });
    }

    public async Task UpdateListAsync(Guid id, ToDoListRequest request)
    {
        var list = await _toDoListRepository.GetByIdOrThrowAsync(id);

        list.Name = request.Name;

        await _toDoListRepository.UpdateAsync(list);
    }

    public async Task DeleteListAsync(Guid id)
    {
        var list = await _toDoListRepository.GetByIdOrThrowAsync(id);

        await _toDoListRepository.DeleteAsync(list);
    }

    public async Task<ToDoListItem> AddItemToListAsync(Guid listId, ToDoListItemRequest request)
    {
        var list = await _toDoListRepository.GetByIdOrThrowAsync(listId);

        var item = new ToDoListItem
        {
            Item = request.Item,
            Status = ListItemStatus.ToDo,
            ToDoList = list
        };

        return await _toDoListItemRepository.AddAsync(item);
    }

    public async Task RemoveItemFromListAsync(Guid listId, Guid itemId)
    {
        _ = await _toDoListRepository.GetByIdOrThrowAsync(listId);

        var item = await _toDoListItemRepository.GetByIdOrThrowAsync(itemId);

        await _toDoListItemRepository.DeleteAsync(item);
    }

    public async Task UpdateListItemAsync(Guid listId, Guid itemId, ToDoListItemRequest request)
    {
        _ = await _toDoListRepository.GetByIdOrThrowAsync(listId);

        var item = await _toDoListItemRepository.GetByIdOrThrowAsync(itemId);

        item.Item = request.Item;

        await _toDoListItemRepository.UpdateAsync(item);
    }
}