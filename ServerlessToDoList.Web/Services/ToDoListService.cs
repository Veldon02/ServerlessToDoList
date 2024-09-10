using ServerlessToDoList.Web.Entities;
using ServerlessToDoList.Web.Exceptions;
using ServerlessToDoList.Web.Interfaces.Repositories;
using ServerlessToDoList.Web.Interfaces.Services;

namespace ServerlessToDoList.Web.Services;

public class ToDoListService : IToDoListService
{
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListService(IToDoListRepository toDoListRepository)
    {
        _toDoListRepository = toDoListRepository;
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
}