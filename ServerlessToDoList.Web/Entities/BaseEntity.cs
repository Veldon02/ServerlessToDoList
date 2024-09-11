namespace ServerlessToDoList.Web.Entities;

public class BaseEntity<T>
{
    public T Id { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime UpdatedDate { get; set; }
}