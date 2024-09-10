using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using ServerlessToDoList.Web.Interfaces.Services;

namespace ServerlessToDoList.Web.Functions;

public class ToDoListFunction
{
    private readonly IToDoListService _toDoListService;

    public ToDoListFunction(IToDoListService toDoListService)
    {
        _toDoListService = toDoListService;
    }

    [Function("GetAll")]
    public async Task<ActionResult> GetAll(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo-list")] HttpRequest req)
    {
        var result = await _toDoListService.GetAllAsync();
        return new OkObjectResult(result);
    }

    [Function("GetById")]
    public async Task<ActionResult> GetById(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo-list/{id}")] HttpRequest req, Guid id)
    {
        var result = await _toDoListService.GetByIdAsync(id);
        return new OkObjectResult(result);
    }
}