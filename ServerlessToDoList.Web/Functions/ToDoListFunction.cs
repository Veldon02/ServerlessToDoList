using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Newtonsoft.Json;
using ServerlessToDoList.Web.ApiModels.ToDoList;
using ServerlessToDoList.Web.ApiModels.ToDoListItem;
using ServerlessToDoList.Web.Interfaces.Services;

namespace ServerlessToDoList.Web.Functions;

public class ToDoListFunction
{
    private readonly IToDoListService _toDoListService;
    private readonly IMapper _mapper;

    public ToDoListFunction(IToDoListService toDoListService, IMapper mapper)
    {
        _toDoListService = toDoListService;
        _mapper = mapper;
    }

    [Function("GetAllToDoLists")]
    public async Task<ActionResult> GetAll(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo-list")]
        HttpRequest req)
    {
        var result = await _toDoListService.GetAllAsync();

        return new OkObjectResult(_mapper.Map<IEnumerable<ToDoListResponse>>(result));
    }

    [Function("GetToDoListById")]
    public async Task<ActionResult> GetById(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo-list/{id}")]
        HttpRequest req, Guid id)
    {
        var result = await _toDoListService.GetByIdAsync(id);

        return new OkObjectResult(_mapper.Map<ToDoListResponse>(result));
    }

    [Function("GetToDoListItemsById")]
    public async Task<ActionResult> GetItemsById(
        [HttpTrigger(AuthorizationLevel.Function, "get", Route = "todo-list/{id}/items")]
        HttpRequest req, Guid id)
    {
        var result = await _toDoListService.GetListItemsAsync(id);

        return new OkObjectResult(_mapper.Map<IEnumerable<ToDoListItemResponse>>(result));
    }

    [Function("CreateToDoList")]
    public async Task<ActionResult> CreateList(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "todo-list")]
        HttpRequest req)
    {
        var request = await ParseBody<ToDoListRequest>(req.Body);

        var result = await _toDoListService.CreateListAsync(request);

        return new OkObjectResult(_mapper.Map<ToDoListResponse>(result));
    }

    [Function("UpdateToDoList")]
    public async Task<ActionResult> UpdateList(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "todo-list/{id}")]
        HttpRequest req, Guid id)
    {
        var request = await ParseBody<ToDoListRequest>(req.Body);

        await _toDoListService.UpdateListAsync(id, request);

        return new OkResult();
    }

    [Function("DeleteList")]
    public async Task<ActionResult> DeleteList(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "todo-list/{id}")]
        HttpRequest req, Guid id)
    {
        await _toDoListService.DeleteListAsync(id);

        return new OkResult();
    }

    [Function("AddItemToList")]
    public async Task<ActionResult> AddItemToList(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = "todo-list/{id}/items")]
        HttpRequest req, Guid id)
    {
        var request = await ParseBody<ToDoListItemRequest>(req.Body);

        var result = await _toDoListService.AddItemToListAsync(id, request);

        return new OkObjectResult(_mapper.Map<ToDoListItemResponse>(result));
    }

    [Function("RemoveItemFromList")]
    public async Task<ActionResult> RemoveItemFromList(
        [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "todo-list/{listId}/items/{itemId}")]
        HttpRequest req, Guid listId, Guid itemId)
    {
        await _toDoListService.RemoveItemFromListAsync(listId, itemId);

        return new OkResult();
    }

    [Function("UpdateListItem")]
    public async Task<ActionResult> UpdateListItem(
        [HttpTrigger(AuthorizationLevel.Function, "put", Route = "todo-list/{listId}/items/{itemId}")]
        HttpRequest req, Guid listId, Guid itemId)
    {
        var request = await ParseBody<ToDoListItemRequest>(req.Body);

        await _toDoListService.UpdateListItemAsync(listId, itemId, request);

        return new OkResult();
    }

    private async Task<T> ParseBody<T>(Stream body)
    {
        var request = await new StreamReader(body).ReadToEndAsync();
        return JsonConvert.DeserializeObject<T>(request) ?? throw new Exception("Body can not be empty");
    }
}