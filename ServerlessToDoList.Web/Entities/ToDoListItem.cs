using ServerlessToDoList.Web.Enums;

namespace ServerlessToDoList.Web.Entities;

public class ToDoListItem : BaseEntity<Guid>
{
    public string Item { get; set; }

    public ListItemStatus Status { get; set; }
}