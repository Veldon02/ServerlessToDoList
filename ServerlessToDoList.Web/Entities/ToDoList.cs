namespace ServerlessToDoList.Web.Entities;

public class ToDoList : BaseEntity<Guid>
{
    public string Name { get; set; }

    public IEnumerable<ToDoListItem> Items { get; set; }
}