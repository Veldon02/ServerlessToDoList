using ServerlessToDoList.Web.Enums;

namespace ServerlessToDoList.Web.ApiModels.ToDoListItem;

public class ToDoListItemUpdateStatusRequest
{
    public ListItemStatus Status { get; set; }
}