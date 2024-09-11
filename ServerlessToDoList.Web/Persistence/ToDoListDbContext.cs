using Microsoft.EntityFrameworkCore;
using ServerlessToDoList.Web.Entities;

namespace ServerlessToDoList.Web.Persistence;

public class ToDoListDbContext : DbContext
{
    public ToDoListDbContext(DbContextOptions<ToDoListDbContext> options)
        : base(options)
    {
    }

    public DbSet<ToDoList> ToDoLists { get; set; }

    public DbSet<ToDoListItem> ToDoListItems { get; set; }
}