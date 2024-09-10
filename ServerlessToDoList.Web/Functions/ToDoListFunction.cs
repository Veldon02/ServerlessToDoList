using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using ServerlessToDoList.Web.Interfaces.Repositories;

namespace ServerlessToDoList.Web.Functions;

public class ToDoListFunction
{
    private readonly IToDoListRepository _toDoListRepository;

    public ToDoListFunction(IToDoListRepository toDoListRepository)
    {
        _toDoListRepository = toDoListRepository;
    }

    [Function("ToDoListFunction")]
    public async Task<ActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequest req)
    {
        var result = await _toDoListRepository.GetAllAsync();
        return new OkObjectResult(result);
    }
}