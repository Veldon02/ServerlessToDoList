using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Exceptions;
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
        var result = await _toDoListRepository.GetByIdAsync(id)
                     ?? throw new EntityNotFoundException($"ToDoList with id {id} is not found");

        return result;
    }

    public async Task<IEnumerable<ToDoListItem>> GetListItemsAsync(Guid id)
    {
        var list = await _toDoListRepository.GetByIdAsync(id)
                   ?? throw new EntityNotFoundException($"ToDoList with id {id} is not found");

        return await _toDoListItemRepository.GetByListAsync(list.Id);
    }

    public async Task<ToDoList> CreateListAsync(ToDoListRequest request)
    {
        return await _toDoListRepository.AddAsync(new ToDoList { Name = request.Name });
    }

    public async Task UpdateListAsync(Guid id, ToDoListRequest request)
    {
        var list = await _toDoListRepository.GetByIdAsync(id)
                   ?? throw new EntityNotFoundException($"ToDoList with id {id} is not found");

        list.Name = request.Name;

        await _toDoListRepository.UpdateAsync(list);
    }

    public async Task DeleteListAsync(Guid id)
    {
        var list = await _toDoListRepository.GetByIdAsync(id)
                       ?? throw new EntityNotFoundException($"ToDoList with id {id} is not found");

        await _toDoListRepository.DeleteAsync(list);
    }
}