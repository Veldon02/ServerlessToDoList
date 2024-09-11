using ServerlessToDoList.Web.Enums;

namespace ServerlessToDoList.Web.ApiModels.ToDoListItem;

public class ToDoListItemResponse
{
    public Guid Id { get; set; }

    public string Item { get; set; }

    public ListItemStatus Status { get; set; }
}